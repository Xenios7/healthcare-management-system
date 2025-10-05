using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AppointmentSlotDatum
{
    public int Id { get; set; }

    public int SlotStatusId { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public bool Overbooked { get; set; }

    public string? Comment { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public int AppointmentDataId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual AppointmentDatum AppointmentData { get; set; } = null!;

    public virtual AppointmentStatus SlotStatus { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
