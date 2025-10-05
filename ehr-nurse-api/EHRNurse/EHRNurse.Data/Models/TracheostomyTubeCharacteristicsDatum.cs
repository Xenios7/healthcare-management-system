using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class TracheostomyTubeCharacteristicsDatum
{
    public int Id { get; set; }

    public int TubeLengthId { get; set; }

    public int OuterDiameterId { get; set; }

    public int InnerDiameterId { get; set; }

    public int CuffDiameterId { get; set; }

    public int ConsistencyOfTubeId { get; set; }

    public int TubeTypeId { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual TracheostomyConsistencyOfTube ConsistencyOfTube { get; set; } = null!;

    public virtual TracheostomyCuffDiameter CuffDiameter { get; set; } = null!;

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual TracheostomyInnerDiameter InnerDiameter { get; set; } = null!;

    public virtual TracheostomyOuterDiameter OuterDiameter { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual TracheostomyTubeLength TubeLength { get; set; } = null!;

    public virtual TracheostomyTubeType TubeType { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
