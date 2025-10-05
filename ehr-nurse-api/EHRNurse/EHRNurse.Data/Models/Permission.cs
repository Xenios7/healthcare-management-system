using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Permission
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
