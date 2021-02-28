namespace Effectory.Questionnaire.Domain.Questionnaires.Items
{
    public interface IAnswer : IQuestionnaireItem 
    {
        int QuestionId { get; }
        int AnswerId { get; }
        int AnswerType { get; }
    }
}