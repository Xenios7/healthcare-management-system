using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmRoutelist
{
    public int Id { get; set; }

    public string Drugid { get; set; } = null!;

    public int PharmRouteId { get; set; }

    public virtual PharmRoute PharmRoute { get; set; } = null!;
}
