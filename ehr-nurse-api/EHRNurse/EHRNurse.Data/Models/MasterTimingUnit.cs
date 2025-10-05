using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class MasterTimingUnit
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int UnitId { get; set; }

    public virtual ICollection<DietaryHabitsDatum> DietaryHabitsData { get; set; } = new List<DietaryHabitsDatum>();

    public virtual ICollection<MedicationDatum> MedicationDatumDurationOfTreatmentUnits { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<MedicationDatum> MedicationDatumFrequencyOfIntakeUnits { get; set; } = new List<MedicationDatum>();

    public virtual ICollection<SocialHistoryDatum> SocialHistoryData { get; set; } = new List<SocialHistoryDatum>();

    public virtual EhdsiUnit Unit { get; set; } = null!;
}
