using System.Collections.Generic;
using Effectory.Questionnaire.Api.UseCases.GetQuestionsBySubject;
using Effectory.Questionnaire.Domain;
using Effectory.Questionnaire.Domain.Questionnaires.Items;
using Effectory.Questionnaire.Domain.Questionnaires.Items.Questions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Effectory.Questionnaire.Tests.UseCaseTests
{
    public class GetQuestionsBySubjectTests
    {
        private readonly Mock<IFindQuestionsBy> _repositoryMock;
        private readonly SubjectController _sut;

        public GetQuestionsBySubjectTests()
        {
            _repositoryMock = new Mock<IFindQuestionsBy>();
            _sut = new SubjectController(_repositoryMock.Object);
        }

        [Fact]
        public void Should_Return_Questions_Given_Subject_Id()
        {
            const int expectedSubjectId = 2605515;
            const int expectedOffset = 0;
            const int expectedLimit = 1;
            _repositoryMock
                .Setup(x => x.FindQuestionsBy(expectedSubjectId, expectedOffset, expectedLimit))
                .Returns(
                    new List<IQuestion>
                    {
                        new Question(3807638, expectedSubjectId, 0, 1, new Dictionary<string, string>(), new List<IAnswer>()),
                        new Question(3807643, expectedSubjectId, 0, 2, new Dictionary<string, string>(), new List<IAnswer>())
                    });

            var actualResult = _sut.GetQuestionsBySubjectId(expectedSubjectId, expectedOffset, expectedLimit);

            actualResult
                .Should()
                .BeOfType<OkObjectResult>()
                .Which.Value
                .Should()
                .BeOfType<List<IQuestion>>()
                .Which
                .Should()
                .NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Should_Return_Next_Questions_When_Offset_Is_Increased()
        {
            const int expectedSubjectId = 2605515;
            const int expectedOffset = 1;
            const int expectedLimit = 1;
            var expectedQuestion = new Question(
                questionId: 3807643,
                expectedSubjectId,
                answerCategoryType: 0,
                orderNumber: 2,
                texts: new Dictionary<string, string>(),
                answers: new List<IAnswer>());
            _repositoryMock
                .Setup(x => x.FindQuestionsBy(expectedSubjectId, expectedOffset, expectedLimit))
                .Returns(
                    new List<IQuestion>
                    {
                        expectedQuestion
                    });

            var actualResult = _sut.GetQuestionsBySubjectId(expectedSubjectId, expectedOffset, expectedLimit);

            actualResult
                .Should()
                .BeOfType<OkObjectResult>()
                .Which.Value
                .Should()
                .BeOfType<List<IQuestion>>()
                .Which
                .Should()
                .NotBeNull().And.HaveCount(1).And.Contain(expectedQuestion); 
        }
        
        [Fact]
        public void Should_Return_Empty_Question_List_When_There_Is_No_Questions()
        {
            const int expectedSubjectId = 2605515;
            const int expectedOffset = 2;
            const int expectedLimit = 1;
            var expectedQuestion = new Question(
                questionId: 3807643,
                expectedSubjectId,
                answerCategoryType: 0,
                orderNumber: 2,
                texts: new Dictionary<string, string>(),
                answers: new List<IAnswer>());
            _repositoryMock
                .Setup(x => x.FindQuestionsBy(expectedSubjectId, expectedOffset, expectedLimit))
                .Returns(new List<IQuestion>());

            var actualResult = _sut.GetQuestionsBySubjectId(expectedSubjectId, expectedOffset, expectedLimit);

            actualResult
                .Should()
                .BeOfType<OkObjectResult>()
                .Which.Value
                .Should()
                .BeOfType<List<IQuestion>>()
                .Which
                .Should()
                .NotBeNull().And.HaveCount(0);
        }
    }
}