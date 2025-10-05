using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Definition
{
    public int Id { get; set; }

    public string Area { get; set; } = null!;

    public string FieldTable { get; set; } = null!;

    public string FieldName { get; set; } = null!;

    public string FieldDescription { get; set; } = null!;

    public string? FieldExamples { get; set; }

    public bool IsActive { get; set; }
}
