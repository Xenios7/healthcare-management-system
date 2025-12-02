using Microsoft.EntityFrameworkCore;
using EHRNurse.Api.Dto;
using EHRNurse.Api.Interfaces;
using EHRNurse.Data.Models;

namespace EHRNurse.Api.Services
{
    public class InpatientService : IInpatientService
    {
        private readonly AppDbContext _context;

        public InpatientService(AppDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // PHASE 1: Main Inpatient List
        // =========================================================
        public async Task<IEnumerable<InpatientListItemDto>> GetAllInpatientsAsync()
        {
            var patientsQuery = _context.Patients
                .AsNoTracking()
                .Where(p => p.IsActive)
                .Include(p => p.EpisodeCares)
                    .ThenInclude(e => e.AccommodationData)
                        .ThenInclude(a => a.Bed)
                            .ThenInclude(b => b.Room)
                                .ThenInclude(r => r.Ward)
                .Include(p => p.ProblemData);

            var patients = await patientsQuery.ToListAsync();

            var dtoList = patients.Select(p =>
            {
                var activeAccommodation = p.EpisodeCares
                    .SelectMany(e => e.AccommodationData)
                    .FirstOrDefault(a => a.IsActive);

                var wardName = activeAccommodation?.Bed?.Room?.Ward?.Name 
                               ?? activeAccommodation?.Bed?.Room?.WardId.ToString() 
                               ?? "Unassigned";

                var activeDiagnosis = p.ProblemData
                    .FirstOrDefault(pd => pd.IsActive)?.Description 
                    ?? "No Diagnosis";

                return new InpatientListItemDto
                {
                    PatientId = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = CalculateAge(p.DateOfBirth),
                    WardId = wardName,
                    Diagnosis = activeDiagnosis,
                    HasPendingMeds = false, 
                    HasPendingMeals = false
                };
            }).ToList();

            return dtoList;
        }

        // =========================================================
        // PHASE 2: Medication Per Patient 
        // =========================================================
        public async Task<IEnumerable<MedicationListItemDto>> GetMedicationsForPatientAsync(
            int patientId, DateOnly date, string status)
        {
            var filterStatus = status.ToLower().Trim();
            
            var targetDate = DateTime.SpecifyKind(date.ToDateTime(TimeOnly.MinValue), DateTimeKind.Utc);

            var query = _context.MedicationData
                .AsNoTracking()
                .Where(m => m.PatientId == patientId)
                // Filter by Date
                .Where(m => m.OnSetDateTime < targetDate.AddDays(1) && 
                           (m.EndDateTime == null || m.EndDateTime >= targetDate))
                .Include(m => m.Product)
                .Include(m => m.QuantityUnit)
                .Include(m => m.FrequencyOfIntakeUnit)
                .Include(m => m.Patient)
                    .ThenInclude(p => p.EpisodeCares)
                        .ThenInclude(e => e.AccommodationData)
                            .ThenInclude(a => a.Bed)
                                .ThenInclude(b => b.Room)
                                    .ThenInclude(r => r.Ward);

            var dbMeds = await query.ToListAsync();

            var dtoList = dbMeds.Select(m =>
            {
                string currentStatus = m.IsSubmitted ? "Given" : "Not Given";

                var activeAcc = m.Patient.EpisodeCares
                    .SelectMany(e => e.AccommodationData)
                    .FirstOrDefault(a => a.IsActive);
                
                string ward = activeAcc?.Bed?.Room?.Ward?.Name ?? "Unassigned";
                string bed = activeAcc?.Bed?.Name ?? "N/A";

                return new MedicationListItemDto
                {
                    MedicationId = m.Id,
                    PatientId = m.PatientId,
                    PatientName = $"{m.Patient.FirstName} {m.Patient.LastName}",
                    PatientAge = CalculateAge(m.Patient.DateOfBirth),
                    Ward = ward,
                    Bed = bed,
                    DaysInWard = 0,

                    ProductName = m.Product?.ProductName ?? "Unknown Drug",
                    Quantity = m.Quantity,
                    QuantityUnit = m.QuantityUnit?.Description ?? "units",
                    Form = "N/A", 
                    InstructionPatient = m.InstructionPatient,
                    Status = currentStatus,
                    HasReminder = false
                };
            });

            if (filterStatus == "given")
                dtoList = dtoList.Where(x => x.Status == "Given");
            else if (filterStatus.Contains("not"))
                dtoList = dtoList.Where(x => x.Status == "Not Given");

            return dtoList;
        }

        // =========================================================
        // PHASE 3: Nutrition Per Patient 
        // =========================================================
        public async Task<IEnumerable<NutritionListItemDto>> GetNutritionForPatientAsync(
            int patientId, DateOnly date, string status)
        {
            var filterStatus = status.ToLower().Trim();
            var targetDate = date.ToDateTime(TimeOnly.MinValue);
            var startOfDay = targetDate.Date;
            var endOfDay = startOfDay.AddDays(1).AddTicks(-1);
            
            var query = _context.FoodData
                .AsNoTracking()
                .Where(fd => fd.PatientId == patientId)
                .Where(fd => fd.OnSetDateTime >= startOfDay && fd.OnSetDateTime <= endOfDay);

            // Apply status filter
            if (filterStatus == "served" || filterStatus == "completed" || filterStatus == "given")
            {
                query = query.Where(fd => fd.IsSubmitted == true);
            }
            else if (filterStatus == "pending" || filterStatus == "not given" || filterStatus.Contains("not"))
            {
                query = query.Where(fd => fd.IsSubmitted == false);
            }

            var patient = await _context.Patients.FindAsync(patientId);
            var foodRecords = await query.Include(fd => fd.FoodType).ToListAsync();
            
            if (!foodRecords.Any())
            {
                return new List<NutritionListItemDto>();
            }

            // Get accommodation by PatientId
            var latestAccommodation = await _context.AccommodationData
                .Include(a => a.Bed)
                .Where(a => a.PatientId == patientId && a.IsActive)
                .OrderByDescending(a => a.CreationDate)
                .FirstOrDefaultAsync();
            
            // Get ward info from the bed
            string ward = "Unknown";
            string bed = "Unknown";
            
            if (latestAccommodation?.Bed != null)
            {
                bed = latestAccommodation.Bed.Name ?? "Unknown";
                
                // Get ward from bed's room
                var bedWithRoom = await _context.AccommodationBeds
                    .Include(b => b.Room)
                        .ThenInclude(r => r.Ward)
                    .FirstOrDefaultAsync(b => b.Id == latestAccommodation.BedId);
                
                ward = bedWithRoom?.Room?.Ward?.Name ?? "Unknown";
            }
                
            var daysInWard = CalculateDaysInWard(latestAccommodation);

            var result = foodRecords.Select(fd => new NutritionListItemDto
            {
                FoodId = fd.Id,
                PatientId = fd.PatientId,
                PatientName = patient != null ? $"{patient.FirstName} {patient.LastName}" : "Unknown",
                PatientAge = patient != null ? CalculateAge(patient.DateOfBirth) : null,
                Ward = ward,
                Bed = bed,
                DaysInWard = daysInWard,
                FoodType = fd.FoodType?.Display ?? "Unknown",
                FoodTypeCode = fd.FoodType?.Code,
                PortionEatenPercentage = fd.PortionEatenPercentage,
                PortionSize = fd.PortionSize,
                Description = fd.Description,
                OnSetDateTime = DateTime.SpecifyKind(fd.OnSetDateTime, DateTimeKind.Utc),
                Status = fd.IsSubmitted ? "Served" : "Pending",
                HasAllergyWarning = fd.Description != null && 
                                   (fd.Description.ToLower().Contains("allerg") ||
                                    fd.Description.ToLower().Contains("warning"))
            }).ToList();

            return result;
        }

        // =========================================================
        // PHASE 4: Schedule Views 
        // =========================================================
        public async Task<IEnumerable<MedicationListItemDto>> GetMedicationScheduleAsync(
            DateOnly date, string status, string? search)
        {
            return await Task.FromResult(new List<MedicationListItemDto>());
        }

        public async Task<IEnumerable<NutritionListItemDto>> GetNutritionScheduleAsync(
            DateOnly date, string status, string? search)
        {
            return await Task.FromResult(new List<NutritionListItemDto>());
        }

        // =========================================================
        // Helper Methods
        // =========================================================
        private int CalculateAge(DateOnly dateOfBirth)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) age--;
            return age;
        }

        private int CalculateDaysInWard(AccommodationDatum? accommodation)
        {
            if (accommodation?.CreationDate == null)
                return 0;
            return (DateTime.Now - accommodation.CreationDate).Days;
        }
    }
}