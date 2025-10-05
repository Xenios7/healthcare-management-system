using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Pdqv3patient
{
    public int Id { get; set; }

    public string? PatientIdExtension { get; set; }

    public string? PatientIdRoot { get; set; }

    public string? GivenName { get; set; }

    public string? FamilyName { get; set; }

    public string? GenderCode { get; set; }

    public string? GenderDisplay { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? StreetAddress { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? ProviderOrgIdRoot { get; set; }

    public string? ProviderOrgName { get; set; }

    public string? ProviderOrgTelecom { get; set; }

    public int? MatchScore { get; set; }

    public string? SourceSystemId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Pdqv3patientIdentifier> Pdqv3patientIdentifiers { get; set; } = new List<Pdqv3patientIdentifier>();
}
