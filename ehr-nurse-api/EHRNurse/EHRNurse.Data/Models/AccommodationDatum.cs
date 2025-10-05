using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AccommodationDatum
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int? BedId { get; set; }

    public DateTime RegistrationDate { get; set; }

    public DateTime? DischargeDate { get; set; }

    public int AdmissionReasonId { get; set; }

    public string? AdmissionNotes { get; set; }

    public int? EpisodeCareId { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public bool IsActive { get; set; }

    public string? MoveBedNotes { get; set; }

    public virtual ICollection<AccommodationDataHistory> AccommodationDataHistories { get; set; } = new List<AccommodationDataHistory>();

    public virtual AdmissionReason AdmissionReason { get; set; } = null!;

    public virtual AccommodationBed? Bed { get; set; }

    public virtual EpisodeCare? EpisodeCare { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
