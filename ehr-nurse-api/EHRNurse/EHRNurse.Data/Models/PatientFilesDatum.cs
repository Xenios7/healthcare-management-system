using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientFilesDatum
{
    public int Id { get; set; }

    public int FileTypeId { get; set; }

    public string FilePath { get; set; } = null!;

    public string? Notes { get; set; }

    public int PatientId { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual PatientFileType FileType { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
