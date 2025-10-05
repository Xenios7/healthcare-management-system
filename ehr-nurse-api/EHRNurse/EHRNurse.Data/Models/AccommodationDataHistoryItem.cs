using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AccommodationDataHistoryItem
{
    public int Id { get; set; }

    public int AccommodationDataHistoryId { get; set; }

    public int RegistrationStatusId { get; set; }

    public string? Notes { get; set; }

    public int? RejectionReasonId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual AccommodationDataHistory AccommodationDataHistory { get; set; } = null!;

    public virtual PatientRegistrationStatus RegistrationStatus { get; set; } = null!;

    public virtual PatientRejectionReason? RejectionReason { get; set; }

    public virtual User User { get; set; } = null!;
}
