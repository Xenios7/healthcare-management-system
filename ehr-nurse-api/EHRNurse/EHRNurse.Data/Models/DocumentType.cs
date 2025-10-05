using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class DocumentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TranslationId { get; set; }

    public virtual ICollection<PatientDocumentsDatum> PatientDocumentsData { get; set; } = new List<PatientDocumentsDatum>();

    public virtual ICollection<PatientEmergencyContactsDatum> PatientEmergencyContactsData { get; set; } = new List<PatientEmergencyContactsDatum>();

    public virtual Translation Translation { get; set; } = null!;
}
