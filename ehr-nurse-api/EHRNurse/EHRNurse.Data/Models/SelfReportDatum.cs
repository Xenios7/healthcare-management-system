using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SelfReportDatum
{
    public int Id { get; set; }

    public int PainLevelId { get; set; }

    public int MedicationFrequencyId { get; set; }

    public string? Description { get; set; }

    public int PatientId { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual SelfReportMedicationFrequency MedicationFrequency { get; set; } = null!;

    public virtual SelfReportPainLevel PainLevel { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<SelfReportBodyPart> SelfReportBodyParts { get; set; } = new List<SelfReportBodyPart>();

    public virtual ICollection<SelfReportSymptom> SelfReportSymptoms { get; set; } = new List<SelfReportSymptom>();

    public virtual ICollection<SelfReportTimeOfDay> SelfReportTimeOfDays { get; set; } = new List<SelfReportTimeOfDay>();

    public virtual Tenant Tenant { get; set; } = null!;
}
