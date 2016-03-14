using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer.Parser;
using NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer
{
    [InstancePerDependency]
    public class AdditionComparer
    {
        private readonly Func<ParserFactory> _parserFactoryFactory;

        public AdditionComparer(
            Func<ParserFactory> parserFactoryFactory // It's not enterprise unless there is a factory factory 
            )
        {
            _parserFactoryFactory = parserFactoryFactory;
        }

        public Result<CompareResult> Compare(IReadOnlyCollection<Model> models)
        {
            if (models == null)
                throw new ArgumentNullException(nameof(models));

            return SumArguments(models)
                 .InvertToList()
                 .If(ValidateCorrectNumberOfModels(models))
                 .Then(r => r.Distinct().Count())
                 .Then(c => c == 1 ? CompareResult.Same : CompareResult.Different);
        }

        private IEnumerable<Result<int>> SumArguments(IReadOnlyCollection<Model> models)
        {
            var parserFactory = _parserFactoryFactory();
            return models.Select(m =>
                parserFactory.Create(m.Language)
                    .Then(p => p.Parse(m.Additions))
                    .Then(n => n.Sum())
                );
        }

        private IResult ValidateCorrectNumberOfModels(IReadOnlyCollection<Model> models)
        {
            if (models.Count == 0)
                return Result.Failed("At least two additions are required for comparison");

            return Result.Success();
        }
    }
}