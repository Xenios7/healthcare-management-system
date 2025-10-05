using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class EhdsiAbsentOrUnknownMedication
{
    public int Id { get; set; }

    public string CodeSystemId { get; set; } = null!;

    public string CodeSystemVersion { get; set; } = null!;

    public string ConceptCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ValueSetId { get; set; } = null!;

    public string MvcVersion { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<MedicationUnknownDatum> MedicationUnknownData { get; set; } = new List<MedicationUnknownDatum>();

    public virtual ValueSet ValueSet { get; set; } = null!;
}
