using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PregnancyStatusDatum
{
    public int Id { get; set; }

    public DateOnly DateOfObservation { get; set; }

    public int StatusId { get; set; }

    public int? PregnancyEstimatedId { get; set; }

    public DateOnly? EstimatedDate { get; set; }

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

    public virtual EhdsiPregnancyInformation? PregnancyEstimated { get; set; }

    public virtual EhdsiCurrentPregnancyStatus Status { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
