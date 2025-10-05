using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientRegistrationHistoryDatum
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int RegistrationStatusId { get; set; }

    public string? Notes { get; set; }

    public int? RejectionReasonId { get; set; }

    public DateTime CreationDate { get; set; }

    public int TenantId { get; set; }

    public Guid UserId { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual PatientRegistrationStatus RegistrationStatus { get; set; } = null!;

    public virtual PatientRejectionReason? RejectionReason { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
