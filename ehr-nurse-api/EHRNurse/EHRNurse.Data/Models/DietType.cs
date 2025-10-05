using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class DietType
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string System { get; set; } = null!;

    public string Display { get; set; } = null!;

    public string? OtherDisplay { get; set; }

    public virtual ICollection<DietaryHabitsDatum> DietaryHabitsData { get; set; } = new List<DietaryHabitsDatum>();
}
