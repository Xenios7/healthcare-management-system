using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public double? Height { get; set; }

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public int GenderId { get; set; }

    public int? BloodTypeId { get; set; }

    public int RegistrationStatusId { get; set; }

    public DateOnly? DateOfAdmission { get; set; }

    public string? Occupation { get; set; }

    public string? AmountOfIncome { get; set; }

    public string? PlaceOfBirthDistrict { get; set; }

    public int? PlaceOfBirthId { get; set; }

    public int? ClosestRelativesId { get; set; }

    public int? EducationLevelId { get; set; }

    public int? FamilyStatusId { get; set; }

    public int? ReligionId { get; set; }

    public string? ClosestRelativesOther { get; set; }

    public string? EducationLevelOther { get; set; }

    public string? FamilyStatusOther { get; set; }

    public string? ReligionOther { get; set; }

    public int? SourceOfIncomeId { get; set; }

    public Guid? RegistrationAgentId { get; set; }

    public bool? Moh { get; set; }

    public int? AddressDataId { get; set; }

    public string? PicturePath { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public bool IsActive { get; set; }

    public int? ImmobilityStatusId { get; set; }

    public bool? IsImported { get; set; }

    public virtual ICollection<AccommodationDatum> AccommodationData { get; set; } = new List<AccommodationDatum>();

    public virtual ICollection<AccommodationDataHistory> AccommodationDataHistories { get; set; } = new List<AccommodationDataHistory>();

    public virtual AddressDatum? AddressData { get; set; }

    public virtual ICollection<AllergyDatum> AllergyData { get; set; } = new List<AllergyDatum>();

    public virtual ICollection<AllergyUnknownDatum> AllergyUnknownData { get; set; } = new List<AllergyUnknownDatum>();

    public virtual ICollection<AppointmentParticipantActorDatum> AppointmentParticipantActorData { get; set; } = new List<AppointmentParticipantActorDatum>();

    public virtual ICollection<AppointmentPatientDatum> AppointmentPatientData { get; set; } = new List<AppointmentPatientDatum>();

    public virtual ICollection<ArterialBloodGasDatum> ArterialBloodGasData { get; set; } = new List<ArterialBloodGasDatum>();

    public virtual EhdsiBloodGroup? BloodType { get; set; }

    public virtual ICollection<CapnographyDatum> CapnographyData { get; set; } = new List<CapnographyDatum>();

    public virtual ICollection<CarePlanDatum> CarePlanData { get; set; } = new List<CarePlanDatum>();

    public virtual PatientClosestRelative? ClosestRelatives { get; set; }

    public virtual ICollection<ComorbidityDatum> ComorbidityData { get; set; } = new List<ComorbidityDatum>();

    public virtual ICollection<ComplicationDatum> ComplicationData { get; set; } = new List<ComplicationDatum>();

    public virtual ICollection<DietaryHabitsDatum> DietaryHabitsData { get; set; } = new List<DietaryHabitsDatum>();

    public virtual PatientEducationLevel? EducationLevel { get; set; }

    public virtual ICollection<EpisodeCare> EpisodeCares { get; set; } = new List<EpisodeCare>();

    public virtual ICollection<EtiologyDatum> EtiologyData { get; set; } = new List<EtiologyDatum>();

    public virtual PatientFamilyStatus? FamilyStatus { get; set; }

    public virtual ICollection<FoodDatum> FoodData { get; set; } = new List<FoodDatum>();

    public virtual EhdsiAdministrativeGender Gender { get; set; } = null!;

    public virtual ICollection<GlasgowDatum> GlasgowData { get; set; } = new List<GlasgowDatum>();

    public virtual ICollection<GlucoseDatum> GlucoseData { get; set; } = new List<GlucoseDatum>();

    public virtual ICollection<HysteroscopyFileDatum> HysteroscopyFileData { get; set; } = new List<HysteroscopyFileDatum>();

    public virtual ICollection<ImagingDatum> ImagingData { get; set; } = new List<ImagingDatum>();

    public virtual PatientImmobilityStatus? ImmobilityStatus { get; set; }

    public virtual ICollection<IpsCdaDatum> IpsCdaData { get; set; } = new List<IpsCdaDatum>();

    public virtual ICollection<LaboratoryDatum> LaboratoryData { get; set; } = new List<LaboratoryDatum>();

    public virtual ICollection<LaboratoryFilesDatum> LaboratoryFilesData { get; set; } = new List<LaboratoryFilesDatum>();

    public virtual ICollection<MedicalAlertDatum> MedicalAlertData { get; set; } = new List<MedicalAlertDatum>();

    public virtual ICollection<MedicalDeviceUnknownDatum> MedicalDeviceUnknownData { get; set; } = new List<MedicalDeviceUnknownDatum>();

    public virtual ICollection<MedicalDevicesDatum> MedicalDevicesData { get; set; } = new List<MedicalDevicesDatum>();

    public virtual ICollection<MedicalHistoryDatum> MedicalHistoryData { get; set; } = new List<MedicalHistoryDatum>();

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<MedicationUnknownDatum> MedicationUnknownData { get; set; } = new List<MedicationUnknownDatum>();

    public virtual ICollection<NeckSizeDatum> NeckSizeData { get; set; } = new List<NeckSizeDatum>();

    public virtual ICollection<PatientDoctor> PatientDoctors { get; set; } = new List<PatientDoctor>();

    public virtual ICollection<PatientDocumentsDatum> PatientDocumentsData { get; set; } = new List<PatientDocumentsDatum>();

    public virtual ICollection<PatientEmergencyContactsDatum> PatientEmergencyContactsData { get; set; } = new List<PatientEmergencyContactsDatum>();

    public virtual ICollection<PatientFilesDatum> PatientFilesData { get; set; } = new List<PatientFilesDatum>();

    public virtual ICollection<PatientRegistrationHistoryDatum> PatientRegistrationHistoryData { get; set; } = new List<PatientRegistrationHistoryDatum>();

    public virtual EhdsiCountry? PlaceOfBirth { get; set; }

    public virtual ICollection<PregnancyHistoryDatum> PregnancyHistoryData { get; set; } = new List<PregnancyHistoryDatum>();

    public virtual ICollection<PregnancyOutcomeDatum> PregnancyOutcomeData { get; set; } = new List<PregnancyOutcomeDatum>();

    public virtual ICollection<PregnancyStatusDatum> PregnancyStatusData { get; set; } = new List<PregnancyStatusDatum>();

    public virtual ICollection<ProblemDatum> ProblemData { get; set; } = new List<ProblemDatum>();

    public virtual ICollection<ProblemUnknownDatum> ProblemUnknownData { get; set; } = new List<ProblemUnknownDatum>();

    public virtual ICollection<ProcedureDatum> ProcedureData { get; set; } = new List<ProcedureDatum>();

    public virtual ICollection<ProcedureUnknownDatum> ProcedureUnknownData { get; set; } = new List<ProcedureUnknownDatum>();

    public virtual ICollection<QuestionnaireDatum> QuestionnaireData { get; set; } = new List<QuestionnaireDatum>();

    public virtual User? RegistrationAgent { get; set; }

    public virtual PatientRegistrationStatus RegistrationStatus { get; set; } = null!;

    public virtual PatientReligion? Religion { get; set; }

    public virtual ICollection<RespiratoryClinicalExaminationDatum> RespiratoryClinicalExaminationData { get; set; } = new List<RespiratoryClinicalExaminationDatum>();

    public virtual ICollection<SelfReportDatum> SelfReportData { get; set; } = new List<SelfReportDatum>();

    public virtual ICollection<SocialHistoryDatum> SocialHistoryData { get; set; } = new List<SocialHistoryDatum>();

    public virtual PatientSourceOfIncome? SourceOfIncome { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<TracheostomyCtParametersDatum> TracheostomyCtParametersData { get; set; } = new List<TracheostomyCtParametersDatum>();

    public virtual ICollection<TracheostomyTubeCharacteristicsDatum> TracheostomyTubeCharacteristicsData { get; set; } = new List<TracheostomyTubeCharacteristicsDatum>();

    public virtual ICollection<TracheostomyTubeInspectionDatum> TracheostomyTubeInspectionData { get; set; } = new List<TracheostomyTubeInspectionDatum>();

    public virtual ICollection<TravelHistoryDatum> TravelHistoryData { get; set; } = new List<TravelHistoryDatum>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<VaccinationDatum> VaccinationData { get; set; } = new List<VaccinationDatum>();

    public virtual ICollection<VitalSignDatum> VitalSignData { get; set; } = new List<VitalSignDatum>();

    public virtual ICollection<WeightDatum> WeightData { get; set; } = new List<WeightDatum>();

    public virtual ICollection<ExternalDoctorsCyma> ExternalDoctorCymas { get; set; } = new List<ExternalDoctorsCyma>();

    public virtual ICollection<ExternalDoctor> ExternalDoctors { get; set; } = new List<ExternalDoctor>();

    public virtual ICollection<PatientInsurance> Insurances { get; set; } = new List<PatientInsurance>();
}
