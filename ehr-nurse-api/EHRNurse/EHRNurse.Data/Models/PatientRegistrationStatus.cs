using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientRegistrationStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TranslationId { get; set; }

    public virtual ICollection<AccommodationDataHistoryItem> AccommodationDataHistoryItems { get; set; } = new List<AccommodationDataHistoryItem>();

    public virtual ICollection<PatientRegistrationHistoryDatum> PatientRegistrationHistoryData { get; set; } = new List<PatientRegistrationHistoryDatum>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual Translation Translation { get; set; } = null!;
}
