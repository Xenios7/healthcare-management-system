using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmPackagesizeunitlist
{
    public int Id { get; set; }

    public string Drugid { get; set; } = null!;

    public int PharmPackagesizeunitId { get; set; }

    public virtual PharmPackagesizeunit PharmPackagesizeunit { get; set; } = null!;
}
