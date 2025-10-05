using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmAtc
{
    public int Id { get; set; }

    public string Atc { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<PharmAtclist> PharmAtclists { get; set; } = new List<PharmAtclist>();
}
