using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class TracheostomyTubeType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<TracheostomyTubeCharacteristicsDatum> TracheostomyTubeCharacteristicsData { get; set; } = new List<TracheostomyTubeCharacteristicsDatum>();
}
