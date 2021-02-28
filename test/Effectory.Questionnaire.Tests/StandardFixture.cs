using Effectory.Questionnaire.Infrastructure.DataAccess;

namespace Effectory.Questionnaire.Tests
{
    public class StandardFixture
    {
        public StandardFixture()
        {
            Repository = new JsonFileRepository(
                new DataSource(),
                new JsonParser());
        }

        public JsonFileRepository Repository { get; }
    }
}