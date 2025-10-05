using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class MasterCategoryModality
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual MasterCategory Category { get; set; } = null!;

    public virtual ICollection<ImagingDatum> ImagingData { get; set; } = new List<ImagingDatum>();
}
