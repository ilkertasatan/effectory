using System.Collections.Generic;
using System.Linq;
using Effectory.Questionnaire.Domain;
using Effectory.Questionnaire.Domain.Questionnaires;
using Effectory.Questionnaire.Domain.Questionnaires.Items;
using Effectory.Questionnaire.Infrastructure.DataAccess.Extensions;
using Newtonsoft.Json.Linq;

namespace Effectory.Questionnaire.Infrastructure.DataAccess
{
    //TODO: This repo might not be proper solution because it's doing file operations...
    //TODO: Maybe migration might be needed
    public class JsonFileRepository : IFindQuestionsBy
    {
        private readonly JObject _queryDataSource;

        public JsonFileRepository(
            ILoadDataSource dataSource,
            IParseJson<JObject> jsonParser)
        {
            _queryDataSource = jsonParser.Parse(dataSource.Load());
        }

        public IEnumerable<IQuestion> FindQuestionsBy(int subjectId, int offset, int limit)
        {
            var questions = new List<IQuestion>();

            foreach (var jsonToken in SelectQuestionsBy(subjectId))
            {
                var questionId = jsonToken["questionId"].ToInt();

                var answers = SelectAnswersBy(questionId)
                    .Select(jt => jt.ToAnswer())
                    .ToList();

                questions.Add(jsonToken.ToQuestion(answers));
            }

            return questions
                .Skip(offset * limit)
                .Take(limit)
                .ToList();
        }
        
        private IEnumerable<JToken> SelectQuestionsBy(int subjectId)
        {
            return _queryDataSource
                .SelectTokens($"$..questionnaireItems[?(@.subjectId == {subjectId})]")
                .Where(q => q["itemType"].ToInt() == (int)ItemType.Question);
        }

        private IEnumerable<JToken> SelectAnswersBy(int questionId)
        {
            return _queryDataSource
                .SelectTokens($"$..questionnaireItems[?(@.questionId == {questionId})]")
                .Where(a => a["itemType"].ToInt() == (int)ItemType.Answer);
        }
    }
}