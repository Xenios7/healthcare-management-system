using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmFormlist
{
    public int Id { get; set; }

    public string Drugid { get; set; } = null!;

    public int PharmFormId { get; set; }

    public virtual PharmForm PharmForm { get; set; } = null!;
}
