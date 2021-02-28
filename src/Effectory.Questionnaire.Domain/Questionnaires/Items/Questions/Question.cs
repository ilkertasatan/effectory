using System.Collections.Generic;

namespace Effectory.Questionnaire.Domain.Questionnaires.Items.Questions
{
    public class Question : IQuestion
    {
        public static readonly IQuestion Empty = new Question();

        private Question()
        {
        }

        public Question(
            int questionId,
            int subjectId,
            int answerCategoryType,
            int orderNumber,
            IDictionary<string, string> texts,
            IList<IAnswer> answers)
        {
            QuestionId = questionId;
            SubjectId = subjectId;
            AnswerCategoryType = answerCategoryType;
            OrderNumber = orderNumber;
            Texts = texts;
            ItemType = ItemType.Question;
            QuestionnaireItems = answers;
        }

        public int QuestionId { get; }
        public int SubjectId { get; }
        public int AnswerCategoryType { get; }
        public int OrderNumber { get; }
        public IDictionary<string, string> Texts { get; }
        public ItemType ItemType { get; }
        public IList<IAnswer> QuestionnaireItems { get; }
    }
}