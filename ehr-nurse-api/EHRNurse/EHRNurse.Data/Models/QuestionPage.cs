using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class QuestionPage
{
    public int Id { get; set; }

    public int TitleTranslationId { get; set; }

    public int Number { get; set; }

    public string? Description { get; set; }

    public int QuestionnaireTemplateId { get; set; }

    public virtual ICollection<QuestionTemplate> QuestionTemplates { get; set; } = new List<QuestionTemplate>();

    public virtual QuestionnaireTemplate QuestionnaireTemplate { get; set; } = null!;

    public virtual Translation1 TitleTranslation { get; set; } = null!;
}
