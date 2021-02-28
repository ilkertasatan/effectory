using System;
using Effectory.Questionnaire.Domain.Questionnaires.UserResponses;

namespace Effectory.Questionnaire.Domain.Questionnaires
{
    public interface IUserResponse
    {
        int Id { get; }
        int UserId { get; }
        int DepartmentId { get; }
        int QuestionnaireId { get; }
        int QuestionId { get; }
        int AnswerId { get; }
        DateTime AnsweredAt { get; }
    }
}