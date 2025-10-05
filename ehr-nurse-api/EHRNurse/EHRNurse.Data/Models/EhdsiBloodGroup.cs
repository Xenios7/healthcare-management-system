using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class EhdsiBloodGroup
{
    public int Id { get; set; }

    public string CodeSystemId { get; set; } = null!;

    public string CodeSystemVersion { get; set; } = null!;

    public string ConceptCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ValueSetId { get; set; } = null!;

    public string MvcVersion { get; set; } = null!;

    public bool IsActive { get; set; }

    public int TranslationId { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual Translation Translation { get; set; } = null!;

    public virtual ValueSet ValueSet { get; set; } = null!;
}
