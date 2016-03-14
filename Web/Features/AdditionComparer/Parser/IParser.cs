using System.Collections.Generic;
using NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer.Parser
{
    public interface IParser
    {
        Result<IReadOnlyCollection<int>> Parse(string input);
    }
}