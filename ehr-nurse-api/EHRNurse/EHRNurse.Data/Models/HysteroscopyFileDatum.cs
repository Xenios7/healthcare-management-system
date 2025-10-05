using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class HysteroscopyFileDatum
{
    public int Id { get; set; }

    public int AnatomicalPositionId { get; set; }

    public DateOnly Date { get; set; }

    public string? Description { get; set; }

    public string? FileType { get; set; }

    public string? Path { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual HysteroscopyAnatomicalPosition AnatomicalPosition { get; set; } = null!;

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
