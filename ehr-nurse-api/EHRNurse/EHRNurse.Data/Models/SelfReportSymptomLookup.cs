using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SelfReportSymptomLookup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SelfReportSymptom> SelfReportSymptoms { get; set; } = new List<SelfReportSymptom>();
}
