using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class LaboratoryGroupLaboratory
{
    public int LaboratoryId { get; set; }

    public int LaboratoryGroupId { get; set; }

    public bool IsRequired { get; set; }

    public virtual Laboratory Laboratory { get; set; } = null!;

    public virtual LaboratoryGroup LaboratoryGroup { get; set; } = null!;
}
