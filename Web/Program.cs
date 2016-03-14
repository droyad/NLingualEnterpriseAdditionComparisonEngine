using System;
using Nancy.Hosting.Self;
using NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing;

namespace NLingualEnterpriseAdditionComparisonEngine.Web
{
    public class Program
    {
        public static void Main()
        {
            const string port = "4242";

            var lifetimeScope = IoC.Incorporate();
            using (var host = new NancyHost(new MyBootstrapper(lifetimeScope), new Uri($"http://localhost:{port}")))
            {
                host.Start();
                Console.WriteLine($"Listening on port {port}");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}
