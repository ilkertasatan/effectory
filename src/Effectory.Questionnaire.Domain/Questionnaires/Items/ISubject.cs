using System.Collections.Generic;

namespace Effectory.Questionnaire.Domain.Questionnaires.Items
{
    public interface ISubject : IQuestionnaireItem
    {
        int SubjectId { get; }

        IList<IQuestion> QuestionnaireItems { get; }

        void AddQuestion(IQuestion question);
    }
}