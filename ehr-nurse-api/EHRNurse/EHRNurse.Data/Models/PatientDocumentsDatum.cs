using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class PatientDocumentsDatum
{
    public int Id { get; set; }

    public int DocumentTypeId { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public int DocumentCountryIssuedId { get; set; }

    public int PatientId { get; set; }

    public virtual EhdsiCountry DocumentCountryIssued { get; set; } = null!;

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
