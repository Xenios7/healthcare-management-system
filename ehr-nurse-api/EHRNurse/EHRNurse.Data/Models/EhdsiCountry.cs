using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class EhdsiCountry
{
    public int Id { get; set; }

    public string CodeSystemId { get; set; } = null!;

    public string CodeSystemVersion { get; set; } = null!;

    public string ConceptCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ValueSetId { get; set; } = null!;

    public string MvcVersion { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<AddressDatum> AddressData { get; set; } = new List<AddressDatum>();

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<PatientDocumentsDatum> PatientDocumentsData { get; set; } = new List<PatientDocumentsDatum>();

    public virtual ICollection<PatientEmergencyContactsDatum> PatientEmergencyContactsData { get; set; } = new List<PatientEmergencyContactsDatum>();

    public virtual ICollection<PatientInsurance> PatientInsurances { get; set; } = new List<PatientInsurance>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<TravelHistoryDatum> TravelHistoryData { get; set; } = new List<TravelHistoryDatum>();

    public virtual ICollection<VaccinationDatum> VaccinationData { get; set; } = new List<VaccinationDatum>();

    public virtual ValueSet ValueSet { get; set; } = null!;
}
