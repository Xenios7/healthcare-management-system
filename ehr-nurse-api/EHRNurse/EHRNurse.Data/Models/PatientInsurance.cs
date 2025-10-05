using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientInsurance
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CountryId { get; set; }

    public bool IsActive { get; set; }

    public virtual EhdsiCountry Country { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
