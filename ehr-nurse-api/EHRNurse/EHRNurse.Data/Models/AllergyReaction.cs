using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AllergyReaction
{
    public int Id { get; set; }

    public int? ManifestationId { get; set; }

    public DateOnly? OnSetDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? SeverityId { get; set; }

    public int? CertaintyId { get; set; }

    public string Description { get; set; } = null!;

    public int AllergyId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public virtual AllergyDatum Allergy { get; set; } = null!;

    public virtual EhdsiAllergyCertainty? Certainty { get; set; }

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual EhdsiReactionAllergy? Manifestation { get; set; }

    public virtual EhdsiSeverity? Severity { get; set; }

    public virtual Visit Visit { get; set; } = null!;
}
