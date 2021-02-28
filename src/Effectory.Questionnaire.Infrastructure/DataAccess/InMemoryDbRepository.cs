using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Effectory.Questionnaire.Domain;
using Effectory.Questionnaire.Domain.Questionnaires;
using Effectory.Questionnaire.Domain.Questionnaires.Results;
using Effectory.Questionnaire.Domain.Questionnaires.UserResponses;
using Microsoft.EntityFrameworkCore;

namespace Effectory.Questionnaire.Infrastructure.DataAccess
{
    public class InMemoryDbRepository :
        ISaveUserResponse,
        ICalculateResult //TODO: Having specific interfaces much better than one general. SOL(I)D...
    {
        private readonly QuestionnaireDbContext _dbContext;

        public InMemoryDbRepository(QuestionnaireDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserResponseAsync(
            UserResponse userResponse,
            CancellationToken cancellationToken)
        {
            await _dbContext.UserResponses.AddAsync(userResponse, cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<IResult>> CalculateResultAsync(
            int questionnaireId,
            CancellationToken cancellationToken)
        {
            //TODO: This is not production ready code, it has to be optimized!
            //TODO: The results might not be correct but have no time to fix!
            //TODO: Formulas should be defined, based on formulas find more appropriate solution!
            //TODO: My approach is relational db but non-relational might be appropriate more than relational! have no time to use no-sql
            var responses = await _dbContext.UserResponses
                .Where(ur => ur.QuestionnaireId == questionnaireId)
                .GroupBy(ur => new {ur.DepartmentId, ur.QuestionId})
                .Select(r => new
                    {
                        r.Key.DepartmentId,
                        r.Key.QuestionId,
                        _dbContext.UserResponses
                            .GroupBy(ur => ur.DepartmentId == r.Key.DepartmentId &&
                                          ur.QuestionId == r.Key.QuestionId)
                            .Select(x => new {Min = x.Count()})
                            .OrderBy(x => x.Min)
                            .First().Min,
                        _dbContext.UserResponses
                            .GroupBy(ur => ur.DepartmentId == r.Key.DepartmentId &&
                                          ur.QuestionId == r.Key.QuestionId)
                            .Select(x => new {Max = x.Count()})
                            .OrderByDescending(x => x.Max)
                            .First().Max
                    }
                ).ToListAsync(cancellationToken);

            var result = new List<IResult>();
            foreach (var response in responses)
            {
                //TODO: Calculating avg is not true, but there is no formula...? I suppose (user response count / answer count) by questions
                //TODO: Should we fetch questionnaire.json and parse it to calculate avg?
                var avg = 0;

                result.Add(new Result(
                    ((Department)response.DepartmentId).ToString(),
                    response.QuestionId,
                    response.Min,
                    response.Max,
                    avg));
            }

            return result;
        }
    }
}