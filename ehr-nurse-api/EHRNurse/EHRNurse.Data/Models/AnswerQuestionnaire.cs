using System;
using System.Collections.Generic;

namespace EHRNurse.Data.Models;

public partial class AnswerQuestionnaire
{
    public int Id { get; set; }

    public int QuestionnaireTemplateId { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreatedDateUtc { get; set; }

    public DateTime UpdatedTimeUtc { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual QuestionnaireTemplate QuestionnaireTemplate { get; set; } = null!;
}
