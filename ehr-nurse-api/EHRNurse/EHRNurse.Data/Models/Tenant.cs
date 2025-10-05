using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Tenant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public virtual ICollection<AccommodationBed> AccommodationBeds { get; set; } = new List<AccommodationBed>();

    public virtual ICollection<AccommodationBuilding> AccommodationBuildings { get; set; } = new List<AccommodationBuilding>();

    public virtual ICollection<AccommodationDatum> AccommodationData { get; set; } = new List<AccommodationDatum>();

    public virtual ICollection<AccommodationDataHistory> AccommodationDataHistories { get; set; } = new List<AccommodationDataHistory>();

    public virtual ICollection<AccommodationFloor> AccommodationFloors { get; set; } = new List<AccommodationFloor>();

    public virtual ICollection<AccommodationRoom> AccommodationRooms { get; set; } = new List<AccommodationRoom>();

    public virtual ICollection<AccommodationWard> AccommodationWards { get; set; } = new List<AccommodationWard>();

    public virtual ICollection<AllergyDatum> AllergyData { get; set; } = new List<AllergyDatum>();

    public virtual ICollection<AllergyUnknownDatum> AllergyUnknownData { get; set; } = new List<AllergyUnknownDatum>();

    public virtual ICollection<AppointmentDatum> AppointmentData { get; set; } = new List<AppointmentDatum>();

    public virtual ICollection<AppointmentPatientDatum> AppointmentPatientData { get; set; } = new List<AppointmentPatientDatum>();

    public virtual ICollection<ArterialBloodGasDatum> ArterialBloodGasData { get; set; } = new List<ArterialBloodGasDatum>();

    public virtual ICollection<CapnographyDatum> CapnographyData { get; set; } = new List<CapnographyDatum>();

    public virtual ICollection<CarePlanDatum> CarePlanData { get; set; } = new List<CarePlanDatum>();

    public virtual ICollection<ComorbidityDatum> ComorbidityData { get; set; } = new List<ComorbidityDatum>();

    public virtual ICollection<ComplicationDatum> ComplicationData { get; set; } = new List<ComplicationDatum>();

    public virtual ICollection<DietaryHabitsDatum> DietaryHabitsData { get; set; } = new List<DietaryHabitsDatum>();

    public virtual ICollection<DischargeDatum> DischargeData { get; set; } = new List<DischargeDatum>();

    public virtual ICollection<EpisodeCare> EpisodeCares { get; set; } = new List<EpisodeCare>();

    public virtual ICollection<EtiologyDatum> EtiologyData { get; set; } = new List<EtiologyDatum>();

    public virtual ICollection<ExternalDoctor> ExternalDoctors { get; set; } = new List<ExternalDoctor>();

    public virtual ICollection<FoodDatum> FoodData { get; set; } = new List<FoodDatum>();

    public virtual ICollection<GlasgowDatum> GlasgowData { get; set; } = new List<GlasgowDatum>();

    public virtual ICollection<GlucoseDatum> GlucoseData { get; set; } = new List<GlucoseDatum>();

    public virtual ICollection<HysteroscopyFileDatum> HysteroscopyFileData { get; set; } = new List<HysteroscopyFileDatum>();

    public virtual ICollection<ImagingDatum> ImagingData { get; set; } = new List<ImagingDatum>();

    public virtual ICollection<ImagingPredictionDatum> ImagingPredictionData { get; set; } = new List<ImagingPredictionDatum>();

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

    public virtual ICollection<PatientFilesDatum> PatientFilesData { get; set; } = new List<PatientFilesDatum>();

    public virtual ICollection<PatientRegistrationHistoryDatum> PatientRegistrationHistoryData { get; set; } = new List<PatientRegistrationHistoryDatum>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<PregnancyHistoryDatum> PregnancyHistoryData { get; set; } = new List<PregnancyHistoryDatum>();

    public virtual ICollection<PregnancyOutcomeDatum> PregnancyOutcomeData { get; set; } = new List<PregnancyOutcomeDatum>();

    public virtual ICollection<PregnancyStatusDatum> PregnancyStatusData { get; set; } = new List<PregnancyStatusDatum>();

    public virtual ICollection<ProblemDatum> ProblemData { get; set; } = new List<ProblemDatum>();

    public virtual ICollection<ProblemUnknownDatum> ProblemUnknownData { get; set; } = new List<ProblemUnknownDatum>();

    public virtual ICollection<ProcedureDatum> ProcedureData { get; set; } = new List<ProcedureDatum>();

    public virtual ICollection<ProcedureUnknownDatum> ProcedureUnknownData { get; set; } = new List<ProcedureUnknownDatum>();

    public virtual ICollection<QuestionnaireDatum> QuestionnaireData { get; set; } = new List<QuestionnaireDatum>();

    public virtual ICollection<RespiratoryClinicalExaminationDatum> RespiratoryClinicalExaminationData { get; set; } = new List<RespiratoryClinicalExaminationDatum>();

    public virtual ICollection<SelfReportDatum> SelfReportData { get; set; } = new List<SelfReportDatum>();

    public virtual ICollection<SocialHistoryDatum> SocialHistoryData { get; set; } = new List<SocialHistoryDatum>();

    public virtual ICollection<TenantSetting> TenantSettings { get; set; } = new List<TenantSetting>();

    public virtual ICollection<TracheostomyCtParametersDatum> TracheostomyCtParametersData { get; set; } = new List<TracheostomyCtParametersDatum>();

    public virtual ICollection<TracheostomyTubeCharacteristicsDatum> TracheostomyTubeCharacteristicsData { get; set; } = new List<TracheostomyTubeCharacteristicsDatum>();

    public virtual ICollection<TracheostomyTubeInspectionDatum> TracheostomyTubeInspectionData { get; set; } = new List<TracheostomyTubeInspectionDatum>();

    public virtual ICollection<TravelHistoryDatum> TravelHistoryData { get; set; } = new List<TravelHistoryDatum>();

    public virtual ICollection<VaccinationDatum> VaccinationData { get; set; } = new List<VaccinationDatum>();

    public virtual ICollection<VitalSignDatum> VitalSignData { get; set; } = new List<VitalSignDatum>();

    public virtual ICollection<AdmissionReason> AdmissionReasons { get; set; } = new List<AdmissionReason>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<LaboratoryGroup> LaboratoryGroups { get; set; } = new List<LaboratoryGroup>();

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<PatientRejectionReason> RejectionReasons { get; set; } = new List<PatientRejectionReason>();
}
