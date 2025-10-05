using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Street { get; set; } = null!;

    public string Town { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public string District { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual EhdsiCountry Country { get; set; } = null!;
}
