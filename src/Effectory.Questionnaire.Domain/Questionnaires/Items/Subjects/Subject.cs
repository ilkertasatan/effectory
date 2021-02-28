using System.Collections.Generic;

namespace Effectory.Questionnaire.Domain.Questionnaires.Items.Subjects
{
    public class Subject : ISubject
    {
        public Subject(
            int subjectId,
            int orderNumber,
            IDictionary<string, string> texts,
            IList<IQuestion> questions)
        {
            SubjectId = subjectId;
            OrderNumber = orderNumber;
            Texts = texts;
            ItemType = ItemType.Subject;
            QuestionnaireItems = questions;
        }

        public int SubjectId { get; }
        public int OrderNumber { get; }
        public IDictionary<string, string> Texts { get; }
        public ItemType ItemType { get; }
        public IList<IQuestion> QuestionnaireItems { get; }
        public void AddQuestion(IQuestion question)
        {
            QuestionnaireItems.Add(question);
        }
    }
}