using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SelfReportBodyPart
{
    public int Id { get; set; }

    public int SelfReportDataId { get; set; }

    public string Slug { get; set; } = null!;

    public string Area { get; set; } = null!;

    public virtual SelfReportDatum SelfReportData { get; set; } = null!;
}
