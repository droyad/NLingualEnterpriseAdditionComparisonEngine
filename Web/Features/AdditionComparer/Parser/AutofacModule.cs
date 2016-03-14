using System;
using Autofac;
using System.Reflection;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer.Parser
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .InNamespaceOf<AutofacModule>()
                .Where(t => t.IsClass)
                .As<IParser>()
                .SingleInstance()
                .Named<IParser>(t => t.GetCustomAttribute<LanguageAttribute>().Name);
        }
    }
}