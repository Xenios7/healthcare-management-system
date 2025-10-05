using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmRoute
{
    public int Id { get; set; }

    public string? Route { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<PharmRoutelist> PharmRoutelists { get; set; } = new List<PharmRoutelist>();
}
