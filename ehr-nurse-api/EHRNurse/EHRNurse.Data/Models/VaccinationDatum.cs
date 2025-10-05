using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class VaccinationDatum
{
    public int Id { get; set; }

    public int VaccineId { get; set; }

    public int DiseaseTargetedId { get; set; }

    public int NumSeriesDoses { get; set; }

    public string? MedicinalProductName { get; set; }

    public string? MarketingAuthorizationHolder { get; set; }

    public string BatchLotNumber { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly? NextDate { get; set; }

    public int CountryId { get; set; }

    public Guid DoctorId { get; set; }

    public int AdministeringCenterId { get; set; }

    public int PatientId { get; set; }

    public int VisitId { get; set; }

    public int EpisodeCareId { get; set; }

    public bool IsSubmitted { get; set; }

    public int TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public Guid UserId { get; set; }

    public virtual TenantSetting AdministeringCenter { get; set; } = null!;

    public virtual EhdsiCountry Country { get; set; } = null!;

    public virtual EhdsiIllnessandDisorder DiseaseTargeted { get; set; } = null!;

    public virtual User Doctor { get; set; } = null!;

    public virtual EpisodeCare EpisodeCare { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual EhdsiVaccine Vaccine { get; set; } = null!;

    public virtual Visit Visit { get; set; } = null!;
}
