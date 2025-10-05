using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AccommodationBed
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public int OrderBy { get; set; }

    public bool IsAvailable { get; set; }

    public int RoomId { get; set; }

    public int? TranslationId { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<AccommodationDatum> AccommodationData { get; set; } = new List<AccommodationDatum>();

    public virtual AccommodationRoom Room { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual Translation? Translation { get; set; }

    public virtual User User { get; set; } = null!;
}
