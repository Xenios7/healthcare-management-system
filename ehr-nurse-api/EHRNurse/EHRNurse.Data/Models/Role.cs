using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int OrderBy { get; set; }

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
