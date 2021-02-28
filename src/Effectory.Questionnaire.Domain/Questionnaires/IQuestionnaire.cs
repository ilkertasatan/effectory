using System.Collections.Generic;
using Effectory.Questionnaire.Domain.Questionnaires.Items;

namespace Effectory.Questionnaire.Domain.Questionnaires
{
    public interface IQuestionnaire
    {
        int QuestionnaireId { get; }
        IList<ISubject> QuestionnaireItems { get; }
    }
}