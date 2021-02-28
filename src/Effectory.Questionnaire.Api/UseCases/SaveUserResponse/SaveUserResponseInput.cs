using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Effectory.Questionnaire.Api.UseCases.SaveUserResponse
{
    public class SaveUserResponseInput
    {
        [Required] public int UserId { get; set; }

        [Required] public int DepartmentId { get; set; }

        [Required] public int QuestionnaireId { get; set; }

        [Required] public IEnumerable<UserResponses> Responses { get; set; }
    }

    public class UserResponses
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}