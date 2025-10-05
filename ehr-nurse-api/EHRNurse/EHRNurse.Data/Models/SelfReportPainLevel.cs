using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SelfReportPainLevel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Range { get; set; } = null!;

    public virtual ICollection<SelfReportDatum> SelfReportData { get; set; } = new List<SelfReportDatum>();
}
