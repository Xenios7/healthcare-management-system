using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SelfReportSymptom
{
    public int Id { get; set; }

    public int SelfReportDataId { get; set; }

    public int SymptomLookupId { get; set; }

    public virtual SelfReportDatum SelfReportData { get; set; } = null!;

    public virtual SelfReportSymptomLookup SymptomLookup { get; set; } = null!;
}
