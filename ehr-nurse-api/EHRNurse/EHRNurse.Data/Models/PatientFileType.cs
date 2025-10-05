using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientFileType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TranslationId { get; set; }

    public virtual ICollection<PatientFilesDatum> PatientFilesData { get; set; } = new List<PatientFilesDatum>();

    public virtual Translation? Translation { get; set; }
}
