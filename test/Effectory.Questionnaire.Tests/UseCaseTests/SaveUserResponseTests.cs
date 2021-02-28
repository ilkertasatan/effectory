using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Effectory.Questionnaire.Api.UseCases.SaveUserResponse;
using Effectory.Questionnaire.Domain;
using Effectory.Questionnaire.Domain.Questionnaires.UserResponses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Effectory.Questionnaire.Tests.UseCaseTests
{
    public class SaveUserResponseTests
    {
        [Fact]
        public async Task Should_Return_204_When_User_Response_Is_Saved()
        {
            var repositoryMock = new Mock<ISaveUserResponse>();
            repositoryMock
                .Setup(x => x.AddUserResponseAsync(It.IsAny<UserResponse>(), It.IsAny<CancellationToken>()));
            repositoryMock
                .Setup(x => x.SaveAsync(It.IsAny<CancellationToken>()));
            var sut = new UserResponseController(repositoryMock.Object);

            var actualResult = await sut.SaveUserResponseAsync(
                new SaveUserResponseInput
                {
                    UserId = 2728865,
                    DepartmentId = (int)Department.Marketing,
                    QuestionnaireId = 1000,
                    Responses = new List<UserResponses>
                    {
                        new() {QuestionId = 3807638, AnswerId = 17969124}
                    }
                }, CancellationToken.None);

            actualResult
                .Should()
                .BeOfType<NoContentResult>();
        }
    }
}