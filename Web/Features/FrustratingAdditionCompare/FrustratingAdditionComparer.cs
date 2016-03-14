using System;
using System.Linq;
using Autofac;
using NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare.Parsers;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare
{
    [InstancePerDependency]
    public class FrustratingAdditionComparer
    {
        private readonly FrustratingParserFactory _frustratingParserFactory;

        public FrustratingAdditionComparer(FrustratingParserFactory frustratingParserFactory)
        {
            _frustratingParserFactory = frustratingParserFactory;
        }

        public bool Compare(Model[] models)
        {
            if(models == null)
                throw new ArgumentNullException(nameof(models));
            if(models.Length < 2)
                throw new ArgumentException("At least two additions are required for comparison");

            var differentNumberCount = models.Select(m => _frustratingParserFactory.Get(m.Language).Parse(m.Additions))
                .Select(n => n.Sum())
                .Distinct()
                .Count();

            return differentNumberCount == 1;
        }
    }
}