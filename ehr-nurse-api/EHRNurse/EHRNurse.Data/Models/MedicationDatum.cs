using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class MedicationDatum
{
    public int Id { get; set; }

    public int? ProblemId { get; set; }

    public string ProductId { get; set; } = null!;

    public int AtcId { get; set; }

    public int PackageId { get; set; }

    public int ActiveIngredientId { get; set; }

    public double Quantity { get; set; }

    public int QuantityUnitId { get; set; }

    public double FrequencyOfIntakeAmount { get; set; }

    public int FrequencyOfIntakeUnitId { get; set; }

    public double DurationOfTreatmentAmount { get; set; }

    public int DurationOfTreatmentUnitId { get; set; }

    public DateTime OnSetDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public string? InstructionPatient { get; set; }

    public string? AdviceToDispenser { get; set; }

    public int? RouteOfAdministrationId { get; set; }

    public Guid? AssignedDoctorId { get; set; }

    public int? ProfessionId { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public bool IsActive { get; set; }

    public int? ReplacementId { get; set; }

    public virtual PharmActivesubstance ActiveIngredient { get; set; } = null!;

    public virtual User? AssignedDoctor { get; set; }

    public virtual PharmAtc Atc { get; set; } = null!;

    public virtual MasterTimingUnit DurationOfTreatmentUnit { get; set; } = null!;

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual MasterTimingUnit FrequencyOfIntakeUnit { get; set; } = null!;

    public virtual ICollection<MedicationDatum> InverseReplacement { get; set; } = new List<MedicationDatum>();

    public virtual PharmForm Package { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual ProblemDatum? Problem { get; set; }

    public virtual PharmProduct Product { get; set; } = null!;

    public virtual EhdsiHealthcareProfessionalRole? Profession { get; set; }

    public virtual PharmPackagesizeunit QuantityUnit { get; set; } = null!;

    public virtual MedicationDatum? Replacement { get; set; }

    public virtual PharmRoute? RouteOfAdministration { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
