using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Visit
{
    public int Id { get; set; }

    public DateOnly VisitDate { get; set; }

    public int? PotentialDiagnosisId { get; set; }

    public string? Notes { get; set; }

    public Guid DoctorId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsCompleted { get; set; }

    public virtual ICollection<AllergyDatum> AllergyData { get; set; } = new List<AllergyDatum>();

    public virtual ICollection<AllergyReaction> AllergyReactions { get; set; } = new List<AllergyReaction>();

    public virtual ICollection<AllergyUnknownDatum> AllergyUnknownData { get; set; } = new List<AllergyUnknownDatum>();

    public virtual ICollection<ArterialBloodGasDatum> ArterialBloodGasData { get; set; } = new List<ArterialBloodGasDatum>();

    public virtual ICollection<CapnographyDatum> CapnographyData { get; set; } = new List<CapnographyDatum>();

    public virtual ICollection<CarePlanDatum> CarePlanData { get; set; } = new List<CarePlanDatum>();

    public virtual ICollection<ComorbidityDatum> ComorbidityData { get; set; } = new List<ComorbidityDatum>();

    public virtual ICollection<ComplicationDatum> ComplicationData { get; set; } = new List<ComplicationDatum>();

    public virtual ICollection<DietaryHabitsDatum> DietaryHabitsData { get; set; } = new List<DietaryHabitsDatum>();

    public virtual User Doctor { get; set; } = null!;

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual ICollection<EtiologyDatum> EtiologyData { get; set; } = new List<EtiologyDatum>();

    public virtual ICollection<FoodDatum> FoodData { get; set; } = new List<FoodDatum>();

    public virtual ICollection<GlasgowDatum> GlasgowData { get; set; } = new List<GlasgowDatum>();

    public virtual ICollection<GlucoseDatum> GlucoseData { get; set; } = new List<GlucoseDatum>();

    public virtual ICollection<HysteroscopyFileDatum> HysteroscopyFileData { get; set; } = new List<HysteroscopyFileDatum>();

    public virtual ICollection<ImagingDatum> ImagingData { get; set; } = new List<ImagingDatum>();

    public virtual ICollection<LaboratoryDatum> LaboratoryData { get; set; } = new List<LaboratoryDatum>();

    public virtual ICollection<LaboratoryFilesDatum> LaboratoryFilesData { get; set; } = new List<LaboratoryFilesDatum>();

    public virtual ICollection<MedicalAlertDatum> MedicalAlertData { get; set; } = new List<MedicalAlertDatum>();

    public virtual ICollection<MedicalDeviceUnknownDatum> MedicalDeviceUnknownData { get; set; } = new List<MedicalDeviceUnknownDatum>();

    public virtual ICollection<MedicalDevicesDatum> MedicalDevicesData { get; set; } = new List<MedicalDevicesDatum>();

    public virtual ICollection<MedicalHistoryDatum> MedicalHistoryData { get; set; } = new List<MedicalHistoryDatum>();

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<MedicationUnknownDatum> MedicationUnknownData { get; set; } = new List<MedicationUnknownDatum>();

    public virtual ICollection<NeckSizeDatum> NeckSizeData { get; set; } = new List<NeckSizeDatum>();

    public virtual EhdsiIllnessandDisorder? PotentialDiagnosis { get; set; }

    public virtual ICollection<PregnancyHistoryDatum> PregnancyHistoryData { get; set; } = new List<PregnancyHistoryDatum>();

    public virtual ICollection<PregnancyOutcomeDatum> PregnancyOutcomeData { get; set; } = new List<PregnancyOutcomeDatum>();

    public virtual ICollection<PregnancyStatusDatum> PregnancyStatusData { get; set; } = new List<PregnancyStatusDatum>();

    public virtual ICollection<ProblemDatum> ProblemData { get; set; } = new List<ProblemDatum>();

    public virtual ICollection<ProblemUnknownDatum> ProblemUnknownData { get; set; } = new List<ProblemUnknownDatum>();

    public virtual ICollection<ProcedureDatum> ProcedureData { get; set; } = new List<ProcedureDatum>();

    public virtual ICollection<ProcedureUnknownDatum> ProcedureUnknownData { get; set; } = new List<ProcedureUnknownDatum>();

    public virtual ICollection<QuestionnaireDatum> QuestionnaireData { get; set; } = new List<QuestionnaireDatum>();

    public virtual ICollection<RespiratoryClinicalExaminationDatum> RespiratoryClinicalExaminationData { get; set; } = new List<RespiratoryClinicalExaminationDatum>();

    public virtual ICollection<SocialHistoryDatum> SocialHistoryData { get; set; } = new List<SocialHistoryDatum>();

    public virtual ICollection<TracheostomyCtParametersDatum> TracheostomyCtParametersData { get; set; } = new List<TracheostomyCtParametersDatum>();

    public virtual ICollection<TracheostomyTubeCharacteristicsDatum> TracheostomyTubeCharacteristicsData { get; set; } = new List<TracheostomyTubeCharacteristicsDatum>();

    public virtual ICollection<TracheostomyTubeInspectionDatum> TracheostomyTubeInspectionData { get; set; } = new List<TracheostomyTubeInspectionDatum>();

    public virtual ICollection<TravelHistoryDatum> TravelHistoryData { get; set; } = new List<TravelHistoryDatum>();

    public virtual ICollection<VaccinationDatum> VaccinationData { get; set; } = new List<VaccinationDatum>();

    public virtual ICollection<VitalSignDatum> VitalSignData { get; set; } = new List<VitalSignDatum>();

    public virtual ICollection<WeightDatum> WeightData { get; set; } = new List<WeightDatum>();
}
