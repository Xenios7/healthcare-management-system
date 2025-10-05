using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ComorbidityDatum
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public double Iqr { get; set; }

    public bool IsRespiratoryDisease { get; set; }

    public bool IsHypertension { get; set; }

    public bool IsCopd { get; set; }

    public bool IsHeartDisease { get; set; }

    public bool IsDiabetesMellitus { get; set; }

    public bool IsMalignancy { get; set; }

    public bool IsStroke { get; set; }

    public bool IsImmunosuppression { get; set; }

    public bool IsNoComorbidities { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
