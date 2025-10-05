using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class HysteroscopyAnatomicalSubPosition
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int AnatomicalPositionId { get; set; }

    public virtual HysteroscopyAnatomicalPosition AnatomicalPosition { get; set; } = null!;
}
