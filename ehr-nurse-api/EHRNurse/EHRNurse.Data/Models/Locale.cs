using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Locale
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;
}
