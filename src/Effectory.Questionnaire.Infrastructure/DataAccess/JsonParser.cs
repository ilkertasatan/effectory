using Effectory.Questionnaire.Domain;
using Newtonsoft.Json.Linq;

namespace Effectory.Questionnaire.Infrastructure.DataAccess
{
    public class JsonParser : IParseJson<JObject>
    {
        public JObject Parse(string json)
        {
            return JObject.Parse(json, new JsonLoadSettings
            {
                CommentHandling = CommentHandling.Ignore,
                LineInfoHandling = LineInfoHandling.Ignore
            });
        }
    }
}