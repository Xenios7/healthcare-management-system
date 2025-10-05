using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientClosestRelative
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TranslationId { get; set; }

    public virtual ICollection<PatientEmergencyContactsDatum> PatientEmergencyContactsData { get; set; } = new List<PatientEmergencyContactsDatum>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual Translation Translation { get; set; } = null!;
}
