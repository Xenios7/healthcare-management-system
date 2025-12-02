using EHRNurse.Api.Dto;

namespace EHRNurse.Api.Interfaces
{
    public interface IInpatientService
    {
        Task<IEnumerable<InpatientListItemDto>> GetAllInpatientsAsync();
        
        Task<IEnumerable<MedicationListItemDto>> GetMedicationsForPatientAsync(int patientId, DateOnly date, string status);
        
        Task<IEnumerable<NutritionListItemDto>> GetNutritionForPatientAsync(int patientId, DateOnly date, string status);
        
        Task<IEnumerable<MedicationListItemDto>> GetMedicationScheduleAsync(DateOnly date, string status, string? search);
        
        Task<IEnumerable<NutritionListItemDto>> GetNutritionScheduleAsync(DateOnly date, string status, string? search);
    }
}