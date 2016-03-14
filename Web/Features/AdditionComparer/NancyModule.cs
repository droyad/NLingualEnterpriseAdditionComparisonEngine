using Nancy;
using Nancy.ModelBinding;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer
{
    public class NancyModule : Nancy.NancyModule
    {
        public NancyModule(AdditionComparer comparer) : base("/CompareAdditions")
        {
            Post["/"] = p =>
            {
                var models = this.Bind<Model[]>();
                var result = comparer.Compare(models);
                return result.WasSuccessful
                    ? Response.AsJson(new {AreSame = result.Value == CompareResult.Same})
                    : Response.AsJson(new {Errors = result.Errors}, HttpStatusCode.BadRequest);
            };
        }
    }
}