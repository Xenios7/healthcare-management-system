using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Complication
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<ComplicationDatum> ComplicationData { get; set; } = new List<ComplicationDatum>();
}
