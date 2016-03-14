using NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare;
using NUnit.Framework;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing
{
    public class TestHelper
    {
        public static TestCaseData Create(string name, object expected, params object[] arguments)
        {
            var data = new TestCaseData(arguments);
            data.SetName(name);
            data.Returns(expected);
            return data;
        }
    }
}