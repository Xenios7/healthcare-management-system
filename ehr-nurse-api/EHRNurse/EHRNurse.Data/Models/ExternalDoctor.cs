using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ExternalDoctor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? HomeNumber { get; set; }

    public string RegistrationNumber { get; set; } = null!;

    public string? Email { get; set; }

    public int? AddressDataId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public bool IsActive { get; set; }

    public int TenantId { get; set; }

    public virtual AddressDatum? AddressData { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<ExternalDoctorSpecialty> ExternalDoctorSpecialties { get; set; } = new List<ExternalDoctorSpecialty>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
