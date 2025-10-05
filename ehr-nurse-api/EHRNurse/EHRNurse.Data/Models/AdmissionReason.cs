using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AdmissionReason
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TranslationId { get; set; }

    public virtual ICollection<AccommodationDatum> AccommodationData { get; set; } = new List<AccommodationDatum>();

    public virtual Translation Translation { get; set; } = null!;

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
