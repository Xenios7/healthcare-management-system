using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SelfReportMedicationFrequency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SelfReportDatum> SelfReportData { get; set; } = new List<SelfReportDatum>();
}
