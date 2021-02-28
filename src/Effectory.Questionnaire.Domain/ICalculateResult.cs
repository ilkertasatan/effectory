using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Effectory.Questionnaire.Domain.Questionnaires;

namespace Effectory.Questionnaire.Domain
{
    public interface ICalculateResult
    {
        Task<IEnumerable<IResult>> CalculateResultAsync(int questionnaireId, CancellationToken cancellationToken);
    }
}