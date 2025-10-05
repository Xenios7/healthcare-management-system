using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientEmergencyContactsDatum
{
    public int Id { get; set; }

    public int? DocumentTypeId { get; set; }

    public string? DocumentNumber { get; set; }

    public int? DocumentCountryIssuedId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Occupation { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public int? ClosestRelativeId { get; set; }

    public string? ClosestRelativeOther { get; set; }

    public int? AddressDataId { get; set; }

    public int PatientId { get; set; }

    public virtual AddressDatum? AddressData { get; set; }

    public virtual PatientClosestRelative? ClosestRelative { get; set; }

    public virtual EhdsiCountry? DocumentCountryIssued { get; set; }

    public virtual DocumentType? DocumentType { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
