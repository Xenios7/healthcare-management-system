using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientRejectionReason
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TranslationId { get; set; }

    public virtual ICollection<AccommodationDataHistoryItem> AccommodationDataHistoryItems { get; set; } = new List<AccommodationDataHistoryItem>();

    public virtual ICollection<PatientRegistrationHistoryDatum> PatientRegistrationHistoryData { get; set; } = new List<PatientRegistrationHistoryDatum>();

    public virtual Translation Translation { get; set; } = null!;

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
