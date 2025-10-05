using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class MasterExamTitle
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<LaboratoryFilesDatum> LaboratoryFilesData { get; set; } = new List<LaboratoryFilesDatum>();
}
