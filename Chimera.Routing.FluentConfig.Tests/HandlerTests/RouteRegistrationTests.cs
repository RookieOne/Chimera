using System.Linq;
using System.Reflection;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Routing.Default;
using Chimera.StructureMap;
using Chimera.TestingUtilities;
using Xunit;

namespace Chimera.Routing.FluentConfig.Tests.HandlerTests
{
    public class RouteRegistrationTests
    {
        protected void RegisterHandlers()
        {
            var locator = new StructureMapContainer();

            new IocConfig(locator)
                .SetupDefaultConventions()
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(typeof (RoutingEngine)));

            IoC.SetImplementation(locator);

            RegisterRoutes
                .FromAssembly(Assembly.GetAssembly(this.GetType()))
                .FromTypes(t => t.Name.EndsWith("Handler"))
                .UnderResourceName(t => t.Name.Replace("Handler", ""))
                .AllPublicMethods();
        }

        [Fact]
        public void should_only_register_2_routes()
        {
            RegisterHandlers();

            var routingEngine = IoC.Get<IRoutingEngine>();
            routingEngine.GetRouteSignatures().Count().ShouldBe(2);
        }
    }

    public class SimpleHandler
    {
        public void Get()
        {
        }

        public void Get(int id)
        {
        }
    }
}