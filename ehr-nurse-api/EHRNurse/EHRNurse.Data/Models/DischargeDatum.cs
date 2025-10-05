using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class DischargeDatum
{
    public int Id { get; set; }

    public int DischargeTypeId { get; set; }

    public int DischargeSituationId { get; set; }

    public string? DischargeTypeNotes { get; set; }

    public string? DischargeSituationNotes { get; set; }

    public int EpisodeCareId { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual DischargeSituation DischargeSituation { get; set; } = null!;

    public virtual DischargeType DischargeType { get; set; } = null!;

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
