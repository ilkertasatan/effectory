using System.Collections.Generic;

namespace Effectory.Questionnaire.Domain.Questionnaires.Items
{
    public interface IQuestion : IQuestionnaireItem
    {
        int SubjectId { get; }
        int QuestionId { get; }
        int AnswerCategoryType { get; }
        IList<IAnswer> QuestionnaireItems { get; }
    }
}