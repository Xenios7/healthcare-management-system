using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class QuestionTemplate
{
    public int Id { get; set; }

    public int TitleTranslationId { get; set; }

    public int? DescriptionTranslationId { get; set; }

    public int Order { get; set; }

    public int QuestionnaireTemplateId { get; set; }

    public int QuestionPageId { get; set; }

    public int QuestionTypeId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Translation1? DescriptionTranslation { get; set; }

    public virtual QuestionPage QuestionPage { get; set; } = null!;

    public virtual ICollection<QuestionTemplateValue> QuestionTemplateValues { get; set; } = new List<QuestionTemplateValue>();

    public virtual QuestionType QuestionType { get; set; } = null!;

    public virtual QuestionnaireTemplate QuestionnaireTemplate { get; set; } = null!;

    public virtual Translation1 TitleTranslation { get; set; } = null!;
}
