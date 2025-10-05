using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EpisodeCare> EpisodeCares { get; set; } = new List<EpisodeCare>();
}
