using Nancy;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer
{
    public class NancyModule : Nancy.NancyModule
    {
        public NancyModule() : base("/CompareAdditions")
        {
            Post["/"] = p =>
            {

            };
        }
    }
}