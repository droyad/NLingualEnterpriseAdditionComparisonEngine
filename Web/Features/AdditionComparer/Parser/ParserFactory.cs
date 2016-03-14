using System;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer.Parser
{
    [InstancePerDependency]
    public class ParserFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public ParserFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }


        public Result<IParser> Create(string language)
        {
            object parser;
            if (_lifetimeScope.TryResolveNamed(language, typeof (IParser), out parser))
                return Result<IParser>.Success((IParser) parser);

            return Result<IParser>.Failed($"Language {language} is not supported");
        }
    }
}