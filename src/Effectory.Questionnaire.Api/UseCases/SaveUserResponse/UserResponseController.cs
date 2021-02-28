using System.Threading;
using System.Threading.Tasks;
using Effectory.Questionnaire.Domain;
using Effectory.Questionnaire.Domain.Questionnaires.UserResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Effectory.Questionnaire.Api.UseCases.SaveUserResponse
{
    [Route("api/user-responses")]
    [ApiController]
    public class UserResponseController : ControllerBase
    {
        private readonly ISaveUserResponse _repository;

        public UserResponseController(ISaveUserResponse repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveUserResponseAsync(
            [FromBody] SaveUserResponseInput input,
            CancellationToken cancellationToken)
        {
            //TODO: This is not proper way. In this case Api layer is pretending Application layer, but in my real projects both are separated and I use CQRS
            foreach (var answer in input.Responses)
            {
                await _repository.AddUserResponseAsync(
                    new UserResponse(
                        input.UserId,
                        (Department)input.DepartmentId,
                        input.QuestionnaireId,
                        answer.QuestionId,
                        answer.AnswerId
                    ), cancellationToken);
            }
            
            //It increases the performance
            await _repository.SaveAsync(cancellationToken); 

            return NoContent(); //In clean architecture, there will be presenter pattern for this like Output.For(result of X)
        }
    }
}