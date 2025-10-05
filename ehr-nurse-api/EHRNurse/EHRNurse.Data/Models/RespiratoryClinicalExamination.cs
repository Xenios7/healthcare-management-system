using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class RespiratoryClinicalExamination
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<RespiratoryClinicalExaminationDatum> RespiratoryClinicalExaminationData { get; set; } = new List<RespiratoryClinicalExaminationDatum>();
}
