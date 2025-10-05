using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ValueSet
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<EhdsiAbsentOrUnknownAllergy> EhdsiAbsentOrUnknownAllergies { get; set; } = new List<EhdsiAbsentOrUnknownAllergy>();

    public virtual ICollection<EhdsiAbsentOrUnknownDevice> EhdsiAbsentOrUnknownDevices { get; set; } = new List<EhdsiAbsentOrUnknownDevice>();

    public virtual ICollection<EhdsiAbsentOrUnknownMedication> EhdsiAbsentOrUnknownMedications { get; set; } = new List<EhdsiAbsentOrUnknownMedication>();

    public virtual ICollection<EhdsiAbsentOrUnknownProblem> EhdsiAbsentOrUnknownProblems { get; set; } = new List<EhdsiAbsentOrUnknownProblem>();

    public virtual ICollection<EhdsiAbsentOrUnknownProcedure> EhdsiAbsentOrUnknownProcedures { get; set; } = new List<EhdsiAbsentOrUnknownProcedure>();

    public virtual ICollection<EhdsiActiveIngredient> EhdsiActiveIngredients { get; set; } = new List<EhdsiActiveIngredient>();

    public virtual ICollection<EhdsiAdministrativeGender> EhdsiAdministrativeGenders { get; set; } = new List<EhdsiAdministrativeGender>();

    public virtual ICollection<EhdsiAdverseEventType> EhdsiAdverseEventTypes { get; set; } = new List<EhdsiAdverseEventType>();

    public virtual ICollection<EhdsiAllergenNoDrug> EhdsiAllergenNoDrugs { get; set; } = new List<EhdsiAllergenNoDrug>();

    public virtual ICollection<EhdsiAllergiesCustom> EhdsiAllergiesCustoms { get; set; } = new List<EhdsiAllergiesCustom>();

    public virtual ICollection<EhdsiAllergyCertainty> EhdsiAllergyCertainties { get; set; } = new List<EhdsiAllergyCertainty>();

    public virtual ICollection<EhdsiAllergyStatus> EhdsiAllergyStatuses { get; set; } = new List<EhdsiAllergyStatus>();

    public virtual ICollection<EhdsiBloodGroup> EhdsiBloodGroups { get; set; } = new List<EhdsiBloodGroup>();

    public virtual ICollection<EhdsiBloodPressure> EhdsiBloodPressures { get; set; } = new List<EhdsiBloodPressure>();

    public virtual ICollection<EhdsiCertainty> EhdsiCertainties { get; set; } = new List<EhdsiCertainty>();

    public virtual ICollection<EhdsiCodeProb> EhdsiCodeProbs { get; set; } = new List<EhdsiCodeProb>();

    public virtual ICollection<EhdsiConfidentiality> EhdsiConfidentialities { get; set; } = new List<EhdsiConfidentiality>();

    public virtual ICollection<EhdsiCountry> EhdsiCountries { get; set; } = new List<EhdsiCountry>();

    public virtual ICollection<EhdsiCriticality> EhdsiCriticalities { get; set; } = new List<EhdsiCriticality>();

    public virtual ICollection<EhdsiCurrentPregnancyStatus> EhdsiCurrentPregnancyStatuses { get; set; } = new List<EhdsiCurrentPregnancyStatus>();

    public virtual ICollection<EhdsiDisplayLabel> EhdsiDisplayLabels { get; set; } = new List<EhdsiDisplayLabel>();

    public virtual ICollection<EhdsiDocumentCode> EhdsiDocumentCodes { get; set; } = new List<EhdsiDocumentCode>();

    public virtual ICollection<EhdsiDoseForm> EhdsiDoseForms { get; set; } = new List<EhdsiDoseForm>();

    public virtual ICollection<EhdsiHealthcareProfessionalRole> EhdsiHealthcareProfessionalRoles { get; set; } = new List<EhdsiHealthcareProfessionalRole>();

    public virtual ICollection<EhdsiHospitalDischargeReportType> EhdsiHospitalDischargeReportTypes { get; set; } = new List<EhdsiHospitalDischargeReportType>();

    public virtual ICollection<EhdsiIllnessandDisorder> EhdsiIllnessandDisorders { get; set; } = new List<EhdsiIllnessandDisorder>();

    public virtual ICollection<EhdsiLaboratoryReportType> EhdsiLaboratoryReportTypes { get; set; } = new List<EhdsiLaboratoryReportType>();

    public virtual ICollection<EhdsiLanguage> EhdsiLanguages { get; set; } = new List<EhdsiLanguage>();

    public virtual ICollection<EhdsiMedicalDevice> EhdsiMedicalDevices { get; set; } = new List<EhdsiMedicalDevice>();

    public virtual ICollection<EhdsiMedicalImagesType> EhdsiMedicalImagesTypes { get; set; } = new List<EhdsiMedicalImagesType>();

    public virtual ICollection<EhdsiMedicalImagingReportType> EhdsiMedicalImagingReportTypes { get; set; } = new List<EhdsiMedicalImagingReportType>();

    public virtual ICollection<EhdsiNullFlavor> EhdsiNullFlavors { get; set; } = new List<EhdsiNullFlavor>();

    public virtual ICollection<EhdsiOutcomeOfPregnancy> EhdsiOutcomeOfPregnancies { get; set; } = new List<EhdsiOutcomeOfPregnancy>();

    public virtual ICollection<EhdsiPackage> EhdsiPackages { get; set; } = new List<EhdsiPackage>();

    public virtual ICollection<EhdsiPersonalRelationship> EhdsiPersonalRelationships { get; set; } = new List<EhdsiPersonalRelationship>();

    public virtual ICollection<EhdsiPregnancyInformation> EhdsiPregnancyInformations { get; set; } = new List<EhdsiPregnancyInformation>();

    public virtual ICollection<EhdsiProcedure> EhdsiProcedures { get; set; } = new List<EhdsiProcedure>();

    public virtual ICollection<EhdsiQuantityUnit> EhdsiQuantityUnits { get; set; } = new List<EhdsiQuantityUnit>();

    public virtual ICollection<EhdsiRareDisease> EhdsiRareDiseases { get; set; } = new List<EhdsiRareDisease>();

    public virtual ICollection<EhdsiReactionAllergy> EhdsiReactionAllergies { get; set; } = new List<EhdsiReactionAllergy>();

    public virtual ICollection<EhdsiResolutionOutcome> EhdsiResolutionOutcomes { get; set; } = new List<EhdsiResolutionOutcome>();

    public virtual ICollection<EhdsiRoleClass> EhdsiRoleClasses { get; set; } = new List<EhdsiRoleClass>();

    public virtual ICollection<EhdsiRouteofAdministration> EhdsiRouteofAdministrations { get; set; } = new List<EhdsiRouteofAdministration>();

    public virtual ICollection<EhdsiSection> EhdsiSections { get; set; } = new List<EhdsiSection>();

    public virtual ICollection<EhdsiSeverity> EhdsiSeverities { get; set; } = new List<EhdsiSeverity>();

    public virtual ICollection<EhdsiSocialHistory> EhdsiSocialHistories { get; set; } = new List<EhdsiSocialHistory>();

    public virtual ICollection<EhdsiStatusCode> EhdsiStatusCodes { get; set; } = new List<EhdsiStatusCode>();

    public virtual ICollection<EhdsiSubstance> EhdsiSubstances { get; set; } = new List<EhdsiSubstance>();

    public virtual ICollection<EhdsiSubstitutionCode> EhdsiSubstitutionCodes { get; set; } = new List<EhdsiSubstitutionCode>();

    public virtual ICollection<EhdsiTelecomAddress> EhdsiTelecomAddresses { get; set; } = new List<EhdsiTelecomAddress>();

    public virtual ICollection<EhdsiTimingEvent> EhdsiTimingEvents { get; set; } = new List<EhdsiTimingEvent>();

    public virtual ICollection<EhdsiUnit> EhdsiUnits { get; set; } = new List<EhdsiUnit>();

    public virtual ICollection<EhdsiVaccine> EhdsiVaccines { get; set; } = new List<EhdsiVaccine>();
}
