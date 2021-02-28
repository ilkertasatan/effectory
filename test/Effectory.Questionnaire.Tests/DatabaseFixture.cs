using System;
using Effectory.Questionnaire.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Effectory.Questionnaire.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<QuestionnaireDbContext>()
                .UseInMemoryDatabase("IntegrationTests")
                .Options;

            DbContext = new QuestionnaireDbContext(options);
        }

        public QuestionnaireDbContext DbContext { get; }

        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}