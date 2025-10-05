using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PharmQuantityunit
{
    public int Id { get; set; }

    public string QuantityUnit { get; set; } = null!;

    public string Description { get; set; } = null!;
}
