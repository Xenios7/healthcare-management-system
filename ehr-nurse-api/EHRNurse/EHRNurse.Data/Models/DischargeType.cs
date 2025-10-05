using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class DischargeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TranslationId { get; set; }

    public virtual ICollection<DischargeDatum> DischargeData { get; set; } = new List<DischargeDatum>();

    public virtual Translation? Translation { get; set; }
}
