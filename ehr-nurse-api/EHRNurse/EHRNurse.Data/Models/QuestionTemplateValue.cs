using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class QuestionTemplateValue
{
    public int Id { get; set; }

    public int QuestionTemplateId { get; set; }

    public int TranslationId { get; set; }

    public int OrderId { get; set; }

    public virtual QuestionTemplate QuestionTemplate { get; set; } = null!;

    public virtual Translation1 Translation { get; set; } = null!;
}
