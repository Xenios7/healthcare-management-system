using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class QuestionType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<QuestionTemplate> QuestionTemplates { get; set; } = new List<QuestionTemplate>();
}
