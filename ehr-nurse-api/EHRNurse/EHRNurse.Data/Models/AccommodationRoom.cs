using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AccommodationRoom
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int WardId { get; set; }

    public int? TranslationId { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<AccommodationBed> AccommodationBeds { get; set; } = new List<AccommodationBed>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual Translation? Translation { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual AccommodationWard Ward { get; set; } = null!;
}
