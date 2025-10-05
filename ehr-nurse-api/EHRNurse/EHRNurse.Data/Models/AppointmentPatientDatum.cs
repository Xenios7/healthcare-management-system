using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AppointmentPatientDatum
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Comments { get; set; }

    public DateTime StartDate { get; set; }

    public bool IsRejected { get; set; }

    public int PatientId { get; set; }

    public int TenantId { get; set; }

    public Guid? DoctorId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? AppointmentStatusId { get; set; }

    public Guid? UserId { get; set; }

    public virtual AppointmentStatus? AppointmentStatus { get; set; }

    public virtual User? Doctor { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User? User { get; set; }
}
