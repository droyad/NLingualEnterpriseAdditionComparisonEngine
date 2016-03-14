using System;
using Nancy;
using Nancy.ModelBinding;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare
{
    public class NancyModule : Nancy.NancyModule
    {
        public NancyModule(FrustratingAdditionComparer comparer) : base("/ContrivedExample/FrustrateMe")
        {
            Post["/"] = p =>
            {
                try
                {
                    var models = this.Bind<Model[]>();
                    var result = comparer.Compare(models);
                    return Response.AsJson(new {AreSame = result});
                }
                catch (Exception ex)
                {
                    return Response.AsJson(new {Error = ex.Message}, HttpStatusCode.BadRequest);
                }
            };
        }
    }
}