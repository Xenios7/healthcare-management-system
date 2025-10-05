using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AccommodationDataHistory
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public Guid UserId { get; set; }

    public int TenantId { get; set; }

    public bool IsHistorical { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? AccommodationDataId { get; set; }

    public virtual AccommodationDatum? AccommodationData { get; set; }

    public virtual ICollection<AccommodationDataHistoryItem> AccommodationDataHistoryItems { get; set; } = new List<AccommodationDataHistoryItem>();

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
