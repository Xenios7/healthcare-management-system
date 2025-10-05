using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmForm
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Strength { get; set; }

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<PharmFormlist> PharmFormlists { get; set; } = new List<PharmFormlist>();
}
