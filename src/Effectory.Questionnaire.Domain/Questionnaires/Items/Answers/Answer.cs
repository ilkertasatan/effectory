using System.Collections.Generic;

namespace Effectory.Questionnaire.Domain.Questionnaires.Items.Answers
{
    public class Answer : IAnswer
    {
        public Answer(
            int answerId,
            int questionId,
            int answerType,
            int orderNumber,
            IDictionary<string, string> texts)
        {
            AnswerId = answerId;
            QuestionId = questionId;
            AnswerType = answerType;
            OrderNumber = orderNumber;
            Texts = texts;
            ItemType = ItemType.Answer;
        }

        public int AnswerId { get; }
        public int QuestionId { get; }
        public int AnswerType { get; }
        public int OrderNumber { get; }
        public IDictionary<string, string> Texts { get; }
        public ItemType ItemType { get; }
    }
}