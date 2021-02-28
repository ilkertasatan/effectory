using System.Collections.Generic;

namespace Effectory.Questionnaire.Domain.Questionnaires
{
    public interface IQuestionnaireItem
    {
        int OrderNumber { get; }
        IDictionary<string, string> Texts { get; }
        ItemType ItemType { get; }
    }
}