using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmAtclist
{
    public int Id { get; set; }

    public string Drugid { get; set; } = null!;

    public int PharmAtcId { get; set; }

    public virtual PharmAtc PharmAtc { get; set; } = null!;
}
