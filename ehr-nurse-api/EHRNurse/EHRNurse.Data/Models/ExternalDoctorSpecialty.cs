using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ExternalDoctorSpecialty
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string GroupHead { get; set; } = null!;

    public int? TranslationId { get; set; }

    public virtual Translation? Translation { get; set; }

    public virtual ICollection<ExternalDoctor> ExternalDoctors { get; set; } = new List<ExternalDoctor>();
}
