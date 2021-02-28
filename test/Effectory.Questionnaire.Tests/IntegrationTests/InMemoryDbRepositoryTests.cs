using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Effectory.Questionnaire.Domain.Questionnaires.UserResponses;
using Effectory.Questionnaire.Infrastructure.DataAccess;
using FluentAssertions;
using Xunit;

namespace Effectory.Questionnaire.Tests.IntegrationTests
{
    public class InMemoryDbRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly InMemoryDbRepository _sut;
        private readonly CancellationToken _cancellationToken;

        public InMemoryDbRepositoryTests(DatabaseFixture fixture)
        {
            _sut = new InMemoryDbRepository(fixture.DbContext);
            
            var cancellation = new CancellationTokenSource();
            cancellation.CancelAfter(TimeSpan.FromSeconds(10));
            
            _cancellationToken = cancellation.Token;
        }
        
        [Fact]
        public async Task Should_Calculate_Results_Given_User_Responses()
        {
            const int expectedQuestionnaireId = 1000;
            var userResponseByMarketing1 = GivenUserResponse(1, Department.Marketing, expectedQuestionnaireId, 1, 1);
            var userResponseByMarketing2 = GivenUserResponse(1, Department.Marketing, expectedQuestionnaireId, 2, 2);
            var userResponseByMarketing3 = GivenUserResponse(2, Department.Marketing, expectedQuestionnaireId, 1, 3);
            var userResponseByMarketing4 = GivenUserResponse(2, Department.Marketing, expectedQuestionnaireId, 2, 3);
            var userResponseByMarketing5 = GivenUserResponse(3, Department.Marketing, expectedQuestionnaireId, 1, 1);
            await _sut.AddUserResponseAsync(userResponseByMarketing1, _cancellationToken);
            await _sut.AddUserResponseAsync(userResponseByMarketing2, _cancellationToken);
            await _sut.AddUserResponseAsync(userResponseByMarketing3, _cancellationToken);
            await _sut.AddUserResponseAsync(userResponseByMarketing4, _cancellationToken);
            await _sut.AddUserResponseAsync(userResponseByMarketing5, _cancellationToken);
            await _sut.SaveAsync(_cancellationToken);

            var actualResult = (await _sut.CalculateResultAsync(expectedQuestionnaireId, _cancellationToken)).ToList();
            
            actualResult.Should().NotBeNull().And.HaveCountGreaterThan(0);
            actualResult[0].Department.Should().Be("Marketing");
            actualResult[0].Min.Should().Be(2);
            actualResult[0].Max.Should().Be(3);
        }

        private static UserResponse GivenUserResponse(
            int userId,
            Department department,
            int questionnaireId,
            int questionId,
            int answerId)
        {
            return new(userId, department, questionnaireId, questionId, answerId);
        }
    }
}