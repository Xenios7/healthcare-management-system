using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ImagingPredictionDatum
{
    public int Id { get; set; }

    public int ImagingFileId { get; set; }

    public string ContourImagePath { get; set; } = null!;

    public string ProcessedImagePath { get; set; } = null!;

    public string PredictionImagePath { get; set; } = null!;

    public string Dimension { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int TenantId { get; set; }

    public Guid UserId { get; set; }

    public virtual ImagingFilePath ImagingFile { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
