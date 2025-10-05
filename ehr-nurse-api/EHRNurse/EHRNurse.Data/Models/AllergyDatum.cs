using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AllergyDatum
{
    public int Id { get; set; }

    public int AllergyCategoryId { get; set; }

    public int AllergyId { get; set; }

    public int? EventTypeId { get; set; }

    public int? CriticalityId { get; set; }

    public int? AllergyStatusId { get; set; }

    public DateOnly? ResolutionDate { get; set; }

    public string Description { get; set; } = null!;

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual EhdsiAllergiesCustom Allergy { get; set; } = null!;

    public virtual AllergyCategory AllergyCategory { get; set; } = null!;

    public virtual ICollection<AllergyReaction> AllergyReactions { get; set; } = new List<AllergyReaction>();

    public virtual EhdsiAllergyStatus? AllergyStatus { get; set; }

    public virtual EhdsiCriticality? Criticality { get; set; }

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual EhdsiAdverseEventType? EventType { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
