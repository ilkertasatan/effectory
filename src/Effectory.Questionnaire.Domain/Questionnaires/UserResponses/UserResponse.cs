using System;

namespace Effectory.Questionnaire.Domain.Questionnaires.UserResponses
{
    public class UserResponse : IUserResponse
    {
        public UserResponse()
        {
        }
        
        public UserResponse(
            int userId,
            Department department,
            int questionnaireId,
            int questionId,
            int answerId)
        {
            UserId = userId;
            DepartmentId = (int)department;
            QuestionnaireId = questionnaireId;
            QuestionId = questionId;
            AnswerId = answerId;
            AnsweredAt = DateTime.UtcNow;
        }

        public int Id { get; }
        public int UserId { get; }
        public int DepartmentId { get; }
        public int QuestionnaireId { get; }
        public int QuestionId { get; }
        public int AnswerId { get; }
        public DateTime AnsweredAt { get; }
    }
}