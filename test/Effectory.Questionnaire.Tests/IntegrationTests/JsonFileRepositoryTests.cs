using System.Collections.Generic;
using Effectory.Questionnaire.Domain.Questionnaires.Items;
using Effectory.Questionnaire.Infrastructure.DataAccess;
using FluentAssertions;
using Xunit;

namespace Effectory.Questionnaire.Tests.IntegrationTests
{
    public class JsonFileRepositoryTests : IClassFixture<StandardFixture>
    {
        private readonly JsonFileRepository _sut;

        public JsonFileRepositoryTests(StandardFixture fixture)
        {
            _sut = fixture.Repository;
        }

        [Fact]
        public void Should_Find_Questions_By_Subject_Id()
        {
            const int expectedSubjectId = 2605515;

            var actualResult = _sut.FindQuestionsBy(expectedSubjectId, offset: 0, limit: 5);

            actualResult
                .Should()
                .NotBeEmpty()
                .And
                .BeOfType<List<IQuestion>>();
        }
    }
}