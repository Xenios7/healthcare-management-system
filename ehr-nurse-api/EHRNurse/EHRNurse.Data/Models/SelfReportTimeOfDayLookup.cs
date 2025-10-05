using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SelfReportTimeOfDayLookup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SelfReportTimeOfDay> SelfReportTimeOfDays { get; set; } = new List<SelfReportTimeOfDay>();
}
