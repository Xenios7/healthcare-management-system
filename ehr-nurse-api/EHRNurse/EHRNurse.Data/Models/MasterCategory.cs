using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class MasterCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string CategoryCode { get; set; } = null!;

    public virtual ICollection<ImagingDatum> ImagingData { get; set; } = new List<ImagingDatum>();

    public virtual ICollection<LaboratoryFilesDatum> LaboratoryFilesData { get; set; } = new List<LaboratoryFilesDatum>();

    public virtual ICollection<MasterCategoryModality> MasterCategoryModalities { get; set; } = new List<MasterCategoryModality>();
}
