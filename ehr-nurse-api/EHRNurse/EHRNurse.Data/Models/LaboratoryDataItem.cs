using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class LaboratoryDataItem
{
    public int LaboratoryDataId { get; set; }

    public int LaboratoryId { get; set; }

    public double Value { get; set; }

    public virtual Laboratory Laboratory { get; set; } = null!;

    public virtual LaboratoryDatum LaboratoryData { get; set; } = null!;
}
