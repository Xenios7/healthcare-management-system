using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class EhdsiIllnessandDisorder
{
    public int Id { get; set; }

    public string CodeSystemId { get; set; } = null!;

    public string CodeSystemVersion { get; set; } = null!;

    public string ConceptCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ValueSetId { get; set; } = null!;

    public string MvcVersion { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<EpisodeCare> EpisodeCares { get; set; } = new List<EpisodeCare>();

    public virtual ICollection<ProblemDatum> ProblemData { get; set; } = new List<ProblemDatum>();

    public virtual ICollection<VaccinationDatum> VaccinationData { get; set; } = new List<VaccinationDatum>();

    public virtual ValueSet ValueSet { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
