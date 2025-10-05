using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ImagingFilePath
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public int ImagingDataId { get; set; }

    public virtual ImagingDatum ImagingData { get; set; } = null!;

    public virtual ICollection<ImagingPredictionDatum> ImagingPredictionData { get; set; } = new List<ImagingPredictionDatum>();
}
