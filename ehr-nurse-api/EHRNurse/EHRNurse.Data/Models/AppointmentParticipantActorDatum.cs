using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AppointmentParticipantActorDatum
{
    public int Id { get; set; }

    public string Reference { get; set; } = null!;

    public string Display { get; set; } = null!;

    public int? PatientId { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<AppointmentParticipantDatum> AppointmentParticipantData { get; set; } = new List<AppointmentParticipantDatum>();

    public virtual Patient? Patient { get; set; }

    public virtual User? User { get; set; }
}
