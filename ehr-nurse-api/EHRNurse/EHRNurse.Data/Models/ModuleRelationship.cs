using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ModuleRelationship
{
    public int Id { get; set; }

    public int ParentModuleId { get; set; }

    public int ChildModuleId { get; set; }

    public virtual Module ChildModule { get; set; } = null!;

    public virtual Module ParentModule { get; set; } = null!;
}
