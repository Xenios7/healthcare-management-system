using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AccommodationWard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FloorId { get; set; }

    public int? TranslationId { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<AccommodationRoom> AccommodationRooms { get; set; } = new List<AccommodationRoom>();

    public virtual AccommodationFloor Floor { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual Translation? Translation { get; set; }

    public virtual User User { get; set; } = null!;
}
