using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHRNurse.Data;
using EHRNurse.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EHRNurse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public MedicationsController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet("schedule")]
        public async Task<ActionResult<IEnumerable<MedicationListItemDto>>> GetMedicationSchedule(
            [FromQuery] DateOnly date,
            [FromQuery] string status = "all",
            [FromQuery] string? search = null)
        {


            var targetDate = date.ToDateTime(TimeOnly.MinValue);
            var statusLower = (status ?? "all").Trim().ToLowerInvariant();

            // Base query: medications that are at least somewhat relevant
            IQueryable<MedicationDatum> query = _db.MedicationData
                .AsNoTracking()
                .Include(m => m.Patient)
                .Include(m => m.Product)
                .Include(m => m.Package)
                .Include(m => m.QuantityUnit)
                .Include(m => m.FrequencyOfIntakeUnit)
                .Include(m => m.DurationOfTreatmentUnit)
                .Include(m => m.RouteOfAdministration)
                .Include(m => m.Visit);


            query = query.Where(m =>
                m.OnSetDateTime.Date <= targetDate.Date &&
                (m.EndDateTime == null || m.EndDateTime.Value.Date >= targetDate.Date));

            // Text search on patient + product
            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.ToLower();
                query = query.Where(m =>
                    m.Patient.FirstName.ToLower().Contains(s) ||
                    m.Patient.LastName.ToLower().Contains(s) ||
                    m.Product.ProductName.ToLower().Contains(s));
            }

            var meds = await query.ToListAsync();


            var dtoQuery = meds.Select(m =>
            {
                var derivedStatus = GetDemoStatus(m, targetDate);

                int? age = CalculateAge(m.Patient.DateOfBirth, date);

                // 1) current accommodation (patient’s stay)
                var currentAccommodation = m.EpisodeCare.AccommodationData
                    .Where(a => a.IsActive && (a.DischargeDate == null || a.DischargeDate > targetDate))
                    .OrderByDescending(a => a.RegistrationDate)  // latest stay wins
                    .FirstOrDefault();

                // 2) bed label
                var bedNumber =
                    currentAccommodation?.Bed?.Name
                    ?? currentAccommodation?.BedId?.ToString()
                    ?? "";

                var wardCode =
                    currentAccommodation?.Bed?.Room?.Ward?.Name  // if AccommodationWard has Name
                    ?? currentAccommodation?.Bed?.Room?.WardId.ToString()
                    ?? "";

                // 4) days in ward from patient admission date
                var admissionDate = m.Patient.DateOfAdmission;

                int daysInWard = 0;
                if (admissionDate.HasValue)
                {
                    var adm = admissionDate.Value.ToDateTime(TimeOnly.MinValue);
                    daysInWard = (targetDate.Date - adm.Date).Days;
                    if (daysInWard < 0) daysInWard = 0;
                }


                return new MedicationListItemDto
                {
                    MedicationId = m.Id,
                    PatientId = m.PatientId,
                    PatientName = $"{m.Patient.FirstName} {m.Patient.LastName}",
                    PatientAge = age,

                    Ward = wardCode,
                    Bed = bedNumber,
                    DaysInWard = daysInWard,

                    ProductName = m.Product.ProductName,
                    Form = m.Package.Description,
                    Quantity = m.Quantity,
                    QuantityUnit = m.QuantityUnit.Description,
                    FrequencyAmount = m.FrequencyOfIntakeAmount,
                    FrequencyUnit = m.FrequencyOfIntakeUnit.Description,
                    DurationAmount = m.DurationOfTreatmentAmount,
                    DurationUnit = m.DurationOfTreatmentUnit.Description,
                    Route = m.RouteOfAdministration?.Route,

                    InstructionPatient = m.InstructionPatient,
                    EndDate = m.EndDateTime,

                    Status = derivedStatus,
                    HasReminder = false
                };
            });


            dtoQuery = statusLower switch
            {
                "given" => dtoQuery.Where(x => x.Status == "given"),
                "not_given" => dtoQuery.Where(x => x.Status == "not_given"),
                _ => dtoQuery // "all"
            };

            // Simple pagination
            var result = dtoQuery
                .OrderBy(x => x.PatientName)
                .ToList();

            return Ok(result);
        }

        /// <summary>
        /// Demo status derivation WITHOUT changing the DB:
        /// - "given"     = order is not active anymore (ended or deactivated before that date)
        /// - "not_given" = order is active on that date
        /// This is NOT per-dose real administration, just good enough for the project.
        /// </summary>
        private static string GetDemoStatus(MedicationDatum m, DateTime targetDate)
        {
            // Ended / deactivated before that date → consider as "given"
            if (!m.IsActive)
                return "given";

            if (m.EndDateTime.HasValue && m.EndDateTime.Value.Date < targetDate.Date)
                return "given";

            // Active around that date → "not_given"
            if (m.OnSetDateTime.Date <= targetDate.Date &&
                (!m.EndDateTime.HasValue || m.EndDateTime.Value.Date >= targetDate.Date))
                return "not_given";

            // Outside the range (future / irrelevant)
            return "not_relevant";
        }

        /// <summary>
        /// Calculates age in whole years on a specific date.
        /// </summary>
        private static int? CalculateAge(DateOnly? dob, DateOnly onDate)
        {
            if (dob == null)
                return null;

            var birth = dob.Value;
            var today = onDate;

            int age = today.Year - birth.Year;

            if (today < birth.AddYears(age))
                age--;

            return age;
        }

    }
}