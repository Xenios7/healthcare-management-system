using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Package
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LicenceNumber { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
