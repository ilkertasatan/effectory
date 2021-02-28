using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Effectory.Questionnaire.Api.UseCases.CalculateUserResponse;
using Effectory.Questionnaire.Domain;
using Effectory.Questionnaire.Domain.Questionnaires;
using Effectory.Questionnaire.Domain.Questionnaires.Results;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Effectory.Questionnaire.Tests.UseCaseTests
{
    public class CalculateUserResponseTests
    {
        [Fact]
        public async Task Should_Return_200_When_Result_Is_Calculated()
        {
            var repositoryMock = new Mock<ICalculateResult>();
            repositoryMock
                .Setup(x => x.CalculateResultAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<IResult>
                {
                    new Result(
                        "department",
                        min: 1, max: 1, questionId: 1, avg: 1)
                });
            var sut = new UserResponseController(repositoryMock.Object);

            var actualResult = await sut.CalculateUserResponsesAsync(questionnaireId: 1000, CancellationToken.None);

            actualResult
                .Should()
                .BeOfType<OkObjectResult>()
                .Which.Value
                .Should()
                .BeOfType<List<IResult>>();
        }
    }
}