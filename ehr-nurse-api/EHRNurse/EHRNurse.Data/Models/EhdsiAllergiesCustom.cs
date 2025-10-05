using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class EhdsiAllergiesCustom
{
    public int Id { get; set; }

    public string CodeSystemId { get; set; } = null!;

    public string CodeSystemVersion { get; set; } = null!;

    public string ConceptCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ValueSetId { get; set; } = null!;

    public int AllergyCategoryId { get; set; }

    public string MvcVersion { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual AllergyCategory AllergyCategory { get; set; } = null!;

    public virtual ICollection<AllergyDatum> AllergyData { get; set; } = new List<AllergyDatum>();

    public virtual ValueSet ValueSet { get; set; } = null!;
}
