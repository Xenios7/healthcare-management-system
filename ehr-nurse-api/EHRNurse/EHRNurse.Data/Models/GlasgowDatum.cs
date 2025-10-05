using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class GlasgowDatum
{
    public int Id { get; set; }

    public DateTime OnSetDateTime { get; set; }

    public int EyeOpeningId { get; set; }

    public int MotorResponseId { get; set; }

    public int VerbalResponseId { get; set; }

    public int TotalScore { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual GlasgowEyeOpening EyeOpening { get; set; } = null!;

    public virtual GlasgowMotorResponse MotorResponse { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual GlasgowVerbalResponse VerbalResponse { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
