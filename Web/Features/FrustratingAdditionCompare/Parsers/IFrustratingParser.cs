using System.Collections.Generic;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare.Parsers
{
    public interface IFrustratingParser
    {
        IReadOnlyList<int> Parse(string input);
    }
}