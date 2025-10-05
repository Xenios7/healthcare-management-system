using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class TracheostomyConsistencyOfTube
{
    public int Id { get; set; }

    public double Value { get; set; }

    public virtual ICollection<TracheostomyTubeCharacteristicsDatum> TracheostomyTubeCharacteristicsData { get; set; } = new List<TracheostomyTubeCharacteristicsDatum>();
}
