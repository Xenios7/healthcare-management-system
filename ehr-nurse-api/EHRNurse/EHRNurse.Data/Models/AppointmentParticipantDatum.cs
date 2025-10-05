using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AppointmentParticipantDatum
{
    public int Id { get; set; }

    public bool Required { get; set; }

    public int ParticipantStatusId { get; set; }

    public int? ActorId { get; set; }

    public int? AppointmentDataId { get; set; }

    public virtual AppointmentParticipantActorDatum? Actor { get; set; }

    public virtual AppointmentDatum? AppointmentData { get; set; }

    public virtual AppointmentStatus ParticipantStatus { get; set; } = null!;
}
