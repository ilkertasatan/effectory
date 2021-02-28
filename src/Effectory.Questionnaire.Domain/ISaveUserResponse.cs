using System.Threading;
using System.Threading.Tasks;
using Effectory.Questionnaire.Domain.Questionnaires.UserResponses;

namespace Effectory.Questionnaire.Domain
{
    public interface ISaveUserResponse
    {
        Task AddUserResponseAsync(UserResponse userResponse, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}