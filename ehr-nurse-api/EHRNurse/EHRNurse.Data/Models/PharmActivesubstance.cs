using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmActivesubstance
{
    public int Id { get; set; }

    public string ActiveSubstance { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public int UnitId { get; set; }

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<PharmActivesubstancelist> PharmActivesubstancelists { get; set; } = new List<PharmActivesubstancelist>();
}
