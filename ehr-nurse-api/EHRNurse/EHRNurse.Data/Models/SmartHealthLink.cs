using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class SmartHealthLink
{
    public Guid Id { get; set; }

    public int PatientId { get; set; }

    public string Manifest { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string Data { get; set; } = null!;

    public string Label { get; set; } = null!;

    public string Passcode { get; set; } = null!;

    public int AccessCount { get; set; }

    public int FailedAccessCount { get; set; }

    public string Link { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }
}
