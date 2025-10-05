using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class VitalSignDatum
{
    public int Id { get; set; }

    public DateTime OnSetDateTime { get; set; }

    public float Temperature { get; set; }

    public float RespiratoryRate { get; set; }

    public float HeartRate { get; set; }

    public float SystolicBloodPressure { get; set; }

    public float DiastolicBloodPressure { get; set; }

    public float? UrineOutput { get; set; }

    public float SpO2 { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
