using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AppointmentStatusType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AppointmentStatus> AppointmentStatuses { get; set; } = new List<AppointmentStatus>();
}
