namespace Effectory.Questionnaire.Domain.Questionnaires
{
    public interface IResult
    {
        string Department { get; }
        int QuestionId { get; }
        int Min { get; }
        int Max { get; }
        decimal Avg { get; }
    }
}