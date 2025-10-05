using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AllergyCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Table { get; set; } = null!;

    public virtual ICollection<AllergyDatum> AllergyData { get; set; } = new List<AllergyDatum>();

    public virtual ICollection<EhdsiAllergiesCustom> EhdsiAllergiesCustoms { get; set; } = new List<EhdsiAllergiesCustom>();
}
