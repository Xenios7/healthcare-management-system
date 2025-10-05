using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class IpsCdaDatum
{
    public int Id { get; set; }

    public string? Path { get; set; }

    public string? Description { get; set; }

    public int PatientId { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
