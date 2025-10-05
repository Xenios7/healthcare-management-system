using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ExternalDoctorsCyma
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int? Specialty1definitionId { get; set; }

    public int? Specialty2definitionId { get; set; }

    public int? Specialty3definitionId { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? MobilePhone { get; set; }

    public string? LandLinePhone { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public int? StatusDefinitionId { get; set; }

    public string? AccountNumber { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool IsActive { get; set; }

    public string? GesyNumber { get; set; }

    public string? SocialInsurance { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
