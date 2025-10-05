using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SelfReportTimeOfDay
{
    public int Id { get; set; }

    public int SelfReportDataId { get; set; }

    public int TimeOfDayLookupId { get; set; }

    public virtual SelfReportDatum SelfReportData { get; set; } = null!;

    public virtual SelfReportTimeOfDayLookup TimeOfDayLookup { get; set; } = null!;
}
