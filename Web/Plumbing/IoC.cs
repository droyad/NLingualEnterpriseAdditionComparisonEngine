using Autofac;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing
{
    internal class IoC
    {
        public static ILifetimeScope Incorporate()
        {
            var builder = new ContainerBuilder();
            var assembly = typeof(IoC).Assembly;
            builder.RegisterAssemblyModules(assembly);
            builder.RegisterByAttributes(assembly);
            return builder.Build();
        }
    }
}