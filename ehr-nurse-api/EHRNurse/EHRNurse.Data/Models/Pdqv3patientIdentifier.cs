using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Pdqv3patientIdentifier
{
    public int Id { get; set; }

    public string? IdentifierRoot { get; set; }

    public string? IdentifierExtension { get; set; }

    public int? Pdqv3patientsId { get; set; }

    public virtual Pdqv3patient? Pdqv3patients { get; set; }
}
