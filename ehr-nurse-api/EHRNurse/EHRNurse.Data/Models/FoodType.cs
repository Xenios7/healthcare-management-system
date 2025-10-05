using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class FoodType
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string System { get; set; } = null!;

    public string Display { get; set; } = null!;

    public string? OtherDisplay { get; set; }

    public virtual ICollection<FoodDatum> FoodData { get; set; } = new List<FoodDatum>();
}
