using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AddressDatum
{
    public int Id { get; set; }

    public string? Street { get; set; }

    public string? Town { get; set; }

    public string? PostCode { get; set; }

    public string? District { get; set; }

    public int? CountryId { get; set; }

    public string? StreetNumber { get; set; }

    public string? ApartmentNumber { get; set; }

    public virtual EhdsiCountry? Country { get; set; }

    public virtual ICollection<ExternalDoctor> ExternalDoctors { get; set; } = new List<ExternalDoctor>();

    public virtual ICollection<PatientEmergencyContactsDatum> PatientEmergencyContactsData { get; set; } = new List<PatientEmergencyContactsDatum>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<TenantSetting> TenantSettings { get; set; } = new List<TenantSetting>();
}
