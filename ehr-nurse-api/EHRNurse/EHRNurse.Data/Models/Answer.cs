using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class Answer
{
    public int Id { get; set; }

    public string? Value { get; set; }

    public int QuestionTemplateId { get; set; }

    public int AnswerQuestionnaireId { get; set; }

    public virtual AnswerQuestionnaire AnswerQuestionnaire { get; set; } = null!;

    public virtual QuestionTemplate QuestionTemplate { get; set; } = null!;
}
