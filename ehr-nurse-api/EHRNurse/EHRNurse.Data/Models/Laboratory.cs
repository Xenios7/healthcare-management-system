using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Laboratory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public double MinValue { get; set; }

    public double MaxValue { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<LaboratoryDataItem> LaboratoryDataItems { get; set; } = new List<LaboratoryDataItem>();

    public virtual ICollection<LaboratoryGroupLaboratory> LaboratoryGroupLaboratories { get; set; } = new List<LaboratoryGroupLaboratory>();
}
