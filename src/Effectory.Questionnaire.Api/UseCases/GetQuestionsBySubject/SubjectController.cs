using System.ComponentModel.DataAnnotations;
using Effectory.Questionnaire.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Effectory.Questionnaire.Api.UseCases.GetQuestionsBySubject
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IFindQuestionsBy _repository;

        public SubjectController(IFindQuestionsBy repository)
        {
            _repository = repository;
        }

        [HttpGet("{subjectId}/questions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetQuestionsBySubjectId(
            [Required] [FromRoute] int subjectId, int offset = 0, int limit = 5)
        {
            //TODO: API layer is pretending Application layer.
            //TODO: Repo should be placed under Application layer.
            //TODO: Fetching questions by subjectId is enough? Do we need any other endpoints?
            var question = _repository.FindQuestionsBy(subjectId, offset, limit);
            return Ok(question);
        }
    }
}