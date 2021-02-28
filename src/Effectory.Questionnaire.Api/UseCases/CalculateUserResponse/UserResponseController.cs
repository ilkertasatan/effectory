using System.Threading;
using System.Threading.Tasks;
using Effectory.Questionnaire.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Effectory.Questionnaire.Api.UseCases.CalculateUserResponse
{
    [Route("api/user-responses")]
    [ApiController]
    public class UserResponseController : ControllerBase
    {
        private readonly ICalculateResult _repository;

        public UserResponseController(ICalculateResult repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculateUserResponsesAsync(
            [FromQuery] int questionnaireId,
            CancellationToken cancellationToken)
        {
            return Ok(await _repository.CalculateResultAsync(questionnaireId, cancellationToken));
        }
    }
}