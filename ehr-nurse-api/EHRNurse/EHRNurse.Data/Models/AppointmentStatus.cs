using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AppointmentStatus
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Display { get; set; } = null!;

    public string Definition { get; set; } = null!;

    public int AppointmentStatusTypeId { get; set; }

    public virtual ICollection<AppointmentDatum> AppointmentData { get; set; } = new List<AppointmentDatum>();

    public virtual ICollection<AppointmentParticipantDatum> AppointmentParticipantData { get; set; } = new List<AppointmentParticipantDatum>();

    public virtual ICollection<AppointmentPatientDatum> AppointmentPatientData { get; set; } = new List<AppointmentPatientDatum>();

    public virtual ICollection<AppointmentSlotDatum> AppointmentSlotData { get; set; } = new List<AppointmentSlotDatum>();

    public virtual AppointmentStatusType AppointmentStatusType { get; set; } = null!;
}
