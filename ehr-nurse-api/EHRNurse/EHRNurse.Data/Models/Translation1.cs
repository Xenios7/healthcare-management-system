using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Translation1
{
    public int Id { get; set; }

    public string En { get; set; } = null!;

    public string Gr { get; set; } = null!;

    public virtual ICollection<QuestionPage> QuestionPages { get; set; } = new List<QuestionPage>();

    public virtual ICollection<QuestionTemplate> QuestionTemplateDescriptionTranslations { get; set; } = new List<QuestionTemplate>();

    public virtual ICollection<QuestionTemplate> QuestionTemplateTitleTranslations { get; set; } = new List<QuestionTemplate>();

    public virtual ICollection<QuestionTemplateValue> QuestionTemplateValues { get; set; } = new List<QuestionTemplateValue>();
}
