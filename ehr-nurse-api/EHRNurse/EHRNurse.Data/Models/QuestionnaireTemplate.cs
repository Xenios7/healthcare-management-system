using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class QuestionnaireTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<AnswerQuestionnaire> AnswerQuestionnaires { get; set; } = new List<AnswerQuestionnaire>();

    public virtual ICollection<QuestionPage> QuestionPages { get; set; } = new List<QuestionPage>();

    public virtual ICollection<QuestionTemplate> QuestionTemplates { get; set; } = new List<QuestionTemplate>();
}
