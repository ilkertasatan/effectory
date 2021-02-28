namespace Effectory.Questionnaire.Domain.Questionnaires.Results
{
    public class Result : IResult
    {
        public Result(
            string department,
            int questionId,
            int min,
            int max,
            decimal avg)
        {
            Department = department;
            QuestionId = questionId;
            Min = min;
            Max = max;
            Avg = avg;
        }
        
        public string Department { get; }
        public int QuestionId { get; }
        public int Min { get; }
        public int Max { get; }
        public decimal Avg { get; }
    }
}