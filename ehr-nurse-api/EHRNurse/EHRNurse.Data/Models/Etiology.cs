using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Etiology
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<EtiologyDatum> EtiologyData { get; set; } = new List<EtiologyDatum>();
}
