using System.Collections.Generic;
using Effectory.Questionnaire.Domain.Questionnaires.Items;
using Effectory.Questionnaire.Domain.Questionnaires.Items.Answers;
using Effectory.Questionnaire.Domain.Questionnaires.Items.Questions;
using Newtonsoft.Json.Linq;

namespace Effectory.Questionnaire.Infrastructure.DataAccess.Extensions
{
    public static class JTokenExtensions
    {
        public static int ToInt(this JToken token)
        {
            return token.Value<int>();
        }

        public static IAnswer ToAnswer(this JToken token)
        {
            return new Answer(
                token["answerId"].ToInt(),
                token["questionId"].ToInt(),
                token["answerType"].ToInt(),
                token["orderNumber"].ToInt(),
                token
                    .SelectToken(".texts")
                    .ToObject<IDictionary<string, string>>());
        }

        public static IQuestion ToQuestion(this JToken token, IList<IAnswer> answers)
        {
            return new Question(
                token["questionId"].ToInt(),
                token["subjectId"].ToInt(),
                token["answerCategoryType"].ToInt(),
                token["orderNumber"].ToInt(),
                token
                    .SelectToken(".texts")
                    .ToObject<IDictionary<string, string>>(),
                answers);
        }
    }
}