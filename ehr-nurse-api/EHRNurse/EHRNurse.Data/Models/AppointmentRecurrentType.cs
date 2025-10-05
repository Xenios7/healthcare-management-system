using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AppointmentRecurrentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AppointmentDatum> AppointmentData { get; set; } = new List<AppointmentDatum>();
}
