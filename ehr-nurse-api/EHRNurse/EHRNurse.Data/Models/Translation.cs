using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Translation
{
    public int Id { get; set; }

    public string DefaultLabel { get; set; } = null!;

    public string En { get; set; } = null!;

    public string Gr { get; set; } = null!;

    public virtual ICollection<AccommodationBed> AccommodationBeds { get; set; } = new List<AccommodationBed>();

    public virtual ICollection<AccommodationBuilding> AccommodationBuildings { get; set; } = new List<AccommodationBuilding>();

    public virtual ICollection<AccommodationFloor> AccommodationFloors { get; set; } = new List<AccommodationFloor>();

    public virtual ICollection<AccommodationRoom> AccommodationRooms { get; set; } = new List<AccommodationRoom>();

    public virtual ICollection<AccommodationWard> AccommodationWards { get; set; } = new List<AccommodationWard>();

    public virtual ICollection<AdmissionReason> AdmissionReasons { get; set; } = new List<AdmissionReason>();

    public virtual ICollection<DischargeSituation> DischargeSituations { get; set; } = new List<DischargeSituation>();

    public virtual ICollection<DischargeType> DischargeTypes { get; set; } = new List<DischargeType>();

    public virtual ICollection<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

    public virtual ICollection<EhdsiAdministrativeGender> EhdsiAdministrativeGenders { get; set; } = new List<EhdsiAdministrativeGender>();

    public virtual ICollection<EhdsiBloodGroup> EhdsiBloodGroups { get; set; } = new List<EhdsiBloodGroup>();

    public virtual ICollection<ExternalDoctorSpecialty> ExternalDoctorSpecialties { get; set; } = new List<ExternalDoctorSpecialty>();

    public virtual ICollection<PatientClosestRelative> PatientClosestRelatives { get; set; } = new List<PatientClosestRelative>();

    public virtual ICollection<PatientEducationLevel> PatientEducationLevels { get; set; } = new List<PatientEducationLevel>();

    public virtual ICollection<PatientFamilyStatus> PatientFamilyStatuses { get; set; } = new List<PatientFamilyStatus>();

    public virtual ICollection<PatientFileType> PatientFileTypes { get; set; } = new List<PatientFileType>();

    public virtual ICollection<PatientImmobilityStatus> PatientImmobilityStatuses { get; set; } = new List<PatientImmobilityStatus>();

    public virtual ICollection<PatientRegistrationStatus> PatientRegistrationStatuses { get; set; } = new List<PatientRegistrationStatus>();

    public virtual ICollection<PatientRejectionReason> PatientRejectionReasons { get; set; } = new List<PatientRejectionReason>();

    public virtual ICollection<PatientReligion> PatientReligions { get; set; } = new List<PatientReligion>();

    public virtual ICollection<PatientSourceOfIncome> PatientSourceOfIncomes { get; set; } = new List<PatientSourceOfIncome>();
}
