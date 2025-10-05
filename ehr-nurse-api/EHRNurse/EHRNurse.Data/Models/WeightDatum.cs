using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class WeightDatum
{
    public int Id { get; set; }

    public double? Weight { get; set; }

    public int PatientId { get; set; }

    public int? VisitId { get; set; }

    public int? EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public DateTime CreationDate { get; set; }

    public Guid UserId { get; set; }

    public string? Description { get; set; }

    public int TenantId { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual EpisodeCare? EpisodeCare { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit? Visit { get; set; }
}
