using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class LaboratoryGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<LaboratoryDatum> LaboratoryData { get; set; } = new List<LaboratoryDatum>();

    public virtual ICollection<LaboratoryGroupLaboratory> LaboratoryGroupLaboratories { get; set; } = new List<LaboratoryGroupLaboratory>();

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
