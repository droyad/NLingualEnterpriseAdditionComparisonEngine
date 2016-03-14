using Autofac;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing
{
    internal class IoC
    {
        public static ILifetimeScope Incorporate()
        {
            var builder = new ContainerBuilder();
            builder.RegisterByAttributes(typeof(IoC).Assembly);
            return builder.Build();
        }
    }
}