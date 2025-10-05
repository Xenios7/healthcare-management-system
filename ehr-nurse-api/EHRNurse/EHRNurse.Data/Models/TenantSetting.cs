using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class TenantSetting
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? CompanyEmail { get; set; }

    public int AddressDataId { get; set; }

    public string? Phone { get; set; }

    public string? LogoPath { get; set; }

    public string? InvoiceLogoPath { get; set; }

    public string? FavIconPath { get; set; }

    public bool IsPilotStudy { get; set; }

    public bool IncludeAppPatient { get; set; }

    public bool IncludePreRegistration { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public Guid? UserId { get; set; }

    public int? MaxUserLimit { get; set; }

    public virtual AddressDatum AddressData { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User? User { get; set; }

    public virtual ICollection<VaccinationDatum> VaccinationData { get; set; } = new List<VaccinationDatum>();
}
