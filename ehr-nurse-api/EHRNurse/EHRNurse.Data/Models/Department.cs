using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public bool IsActive { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
