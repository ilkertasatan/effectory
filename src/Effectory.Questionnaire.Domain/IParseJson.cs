namespace Effectory.Questionnaire.Domain
{
    public interface IParseJson<out T>
    {
        T Parse(string json);
    }
}