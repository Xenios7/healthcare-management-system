using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmPackagesizeunit
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int? CodingId { get; set; }

    public virtual ICollection<MedicationDatum> MedicationData { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<PharmPackagesizeunitlist> PharmPackagesizeunitlists { get; set; } = new List<PharmPackagesizeunitlist>();
}
