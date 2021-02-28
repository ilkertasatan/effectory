using System.Collections.Generic;
using System.Linq;

namespace Effectory.Questionnaire.Api.UseCases.SaveUserResponse.Extensions
{
    public static class SaveUserResponseInputExtensions
    {
        public static IDictionary<int, int> ToDictionary(this SaveUserResponseInput request)
        {
            return request.Responses
                .ToDictionary(
                    a => a.QuestionId,
                    a => a.AnswerId);
        }
    }
}