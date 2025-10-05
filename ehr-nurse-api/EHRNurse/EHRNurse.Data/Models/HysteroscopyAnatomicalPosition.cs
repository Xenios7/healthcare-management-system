using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class HysteroscopyAnatomicalPosition
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<HysteroscopyAnatomicalSubPosition> HysteroscopyAnatomicalSubPositions { get; set; } = new List<HysteroscopyAnatomicalSubPosition>();

    public virtual ICollection<HysteroscopyFileDatum> HysteroscopyFileData { get; set; } = new List<HysteroscopyFileDatum>();
}
