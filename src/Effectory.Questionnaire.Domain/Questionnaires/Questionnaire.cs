using System.Collections.Generic;
using Effectory.Questionnaire.Domain.Questionnaires.Items;

namespace Effectory.Questionnaire.Domain.Questionnaires
{
    public class Questionnaire : IQuestionnaire
    {
        public Questionnaire(
            int questionnaireId,
            IList<ISubject> subjects)
        {
            QuestionnaireId = questionnaireId;
            QuestionnaireItems = subjects;
        }
        
        public int QuestionnaireId { get; }
        public IList<ISubject> QuestionnaireItems { get; }
    }
}