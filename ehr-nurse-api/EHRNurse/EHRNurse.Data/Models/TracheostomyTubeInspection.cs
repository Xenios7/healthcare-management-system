using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class TracheostomyTubeInspection
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<TracheostomyTubeInspectionDatum> TracheostomyTubeInspectionData { get; set; } = new List<TracheostomyTubeInspectionDatum>();
}
