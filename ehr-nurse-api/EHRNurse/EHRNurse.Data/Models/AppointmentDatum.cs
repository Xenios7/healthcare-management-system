using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AppointmentDatum
{
    public int Id { get; set; }

    public int AppointmentStatusId { get; set; }

    public string? Description { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public bool IsDeleted { get; set; }

    public int RecurrentTypeId { get; set; }

    public int? RecurrenceOccurrences { get; set; }

    public virtual ICollection<AppointmentParticipantDatum> AppointmentParticipantData { get; set; } = new List<AppointmentParticipantDatum>();

    public virtual ICollection<AppointmentSlotDatum> AppointmentSlotData { get; set; } = new List<AppointmentSlotDatum>();

    public virtual AppointmentStatus AppointmentStatus { get; set; } = null!;

    public virtual AppointmentRecurrentType RecurrentType { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
