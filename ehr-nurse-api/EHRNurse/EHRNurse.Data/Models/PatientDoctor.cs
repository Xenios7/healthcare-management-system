using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientDoctor
{
    public int PatientId { get; set; }

    public Guid DoctorId { get; set; }

    public bool PrimaryDoctor { get; set; }

    public virtual User Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
