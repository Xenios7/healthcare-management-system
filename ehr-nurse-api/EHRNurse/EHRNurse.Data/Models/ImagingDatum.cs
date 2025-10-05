using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class ImagingDatum
{
    public int Id { get; set; }

    public string ExamTitle { get; set; } = null!;

    public int CategoryId { get; set; }

    public int ModalityId { get; set; }

    public DateOnly Date { get; set; }

    public string Description { get; set; } = null!;

    public string? ReportPath { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual MasterCategory Category { get; set; } = null!;

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual ICollection<ImagingFilePath> ImagingFilePaths { get; set; } = new List<ImagingFilePath>();

    public virtual MasterCategoryModality Modality { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
