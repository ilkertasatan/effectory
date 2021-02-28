using System.Collections.Generic;
using Effectory.Questionnaire.Domain.Questionnaires.Items;

namespace Effectory.Questionnaire.Domain
{
    public interface IFindQuestionsBy
    {
        IEnumerable<IQuestion> FindQuestionsBy(int subjectId, int offset, int limit);
    }
}