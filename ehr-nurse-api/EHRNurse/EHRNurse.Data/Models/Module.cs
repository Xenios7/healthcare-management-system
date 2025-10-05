using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Module
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string Path { get; set; } = null!;

    public int OrderBy { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public virtual ICollection<ModuleRelationship> ModuleRelationshipChildModules { get; set; } = new List<ModuleRelationship>();

    public virtual ICollection<ModuleRelationship> ModuleRelationshipParentModules { get; set; } = new List<ModuleRelationship>();

    public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
