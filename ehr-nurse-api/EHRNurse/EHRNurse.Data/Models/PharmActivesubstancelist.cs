using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmActivesubstancelist
{
    public int Id { get; set; }

    public string Drugid { get; set; } = null!;

    public int PharmActivesubstanceId { get; set; }

    public virtual PharmActivesubstance PharmActivesubstance { get; set; } = null!;
}
