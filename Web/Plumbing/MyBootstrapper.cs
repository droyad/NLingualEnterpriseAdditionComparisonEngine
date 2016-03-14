using Autofac;
using Nancy.Bootstrappers.Autofac;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing
{
    public class MyBootstrapper : AutofacNancyBootstrapper
    {
        private readonly ILifetimeScope _container;

        public MyBootstrapper(ILifetimeScope container)
        {
            _container = container;
        }

        protected override ILifetimeScope GetApplicationContainer()
        {
            return _container;
        }
    }
}