using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class MedicalDeviceAction
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MedicalDevicesDatum> MedicalDevicesData { get; set; } = new List<MedicalDevicesDatum>();
}
