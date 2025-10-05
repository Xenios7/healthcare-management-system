using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class GlasgowVerbalResponse
{
    public int Id { get; set; }

    public string Response { get; set; } = null!;

    public int Score { get; set; }

    public virtual ICollection<GlasgowDatum> GlasgowData { get; set; } = new List<GlasgowDatum>();
}
