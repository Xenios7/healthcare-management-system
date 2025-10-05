using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PregnancyOutcomeDatum
{
    public int Id { get; set; }

    public int OutcomeId { get; set; }

    public int NumberOfChildren { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual EhdsiOutcomeOfPregnancy Outcome { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
