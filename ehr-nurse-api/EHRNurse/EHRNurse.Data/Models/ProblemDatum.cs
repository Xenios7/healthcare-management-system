using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ProblemDatum
{
    public int Id { get; set; }

    public int ProblemId { get; set; }

    public int? IllnessAndDisorderId { get; set; }

    public int? RareDiseaseId { get; set; }

    public int StatusCodeId { get; set; }

    public DateOnly OnSetDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? ResolutionCircumstancesText { get; set; }

    public int? DiagnosisAssertionId { get; set; }

    public string Description { get; set; } = null!;

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public int PatientId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public bool IsActive { get; set; }

    public int? ReplacementId { get; set; }

    public virtual EhdsiCertainty? DiagnosisAssertion { get; set; }

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual EhdsiIllnessandDisorder? IllnessAndDisorder { get; set; }

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();

    public virtual Patient Patient { get; set; } = null!;

    public virtual EhdsiCodeProb Problem { get; set; } = null!;

    public virtual EhdsiRareDisease? RareDisease { get; set; }

    public virtual EhdsiStatusCode StatusCode { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
