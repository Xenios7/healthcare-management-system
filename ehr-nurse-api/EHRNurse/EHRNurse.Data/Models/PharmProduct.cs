using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmProduct
{
    public string Pk { get; set; } = null!;

    public string Drugid { get; set; } = null!;

    public string Packnr { get; set; } = null!;

    public string? Barcode { get; set; }

    public string ProductName { get; set; } = null!;

    public string? PackageDescription { get; set; }

    public string? PackageSize { get; set; }

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();
}
