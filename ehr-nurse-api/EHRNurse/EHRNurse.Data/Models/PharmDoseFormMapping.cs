using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmDoseFormMapping
{
    public int DfId { get; set; }

    public string PharmDoseForm { get; set; } = null!;

    public string MvcDoseForm { get; set; } = null!;

    public short Status { get; set; }
}
