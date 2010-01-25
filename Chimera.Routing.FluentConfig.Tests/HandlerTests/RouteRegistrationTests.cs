using System.Linq;
using System.Reflection;
using Chimera.Framework.IoC.StructureMap;
using Chimera.Framework.Locators;
using Chimera.Framework.Routing.Default.Tests.TestingHelpers;
using Chimera.Framework.Routing.FluentConfig;
using Xunit;

namespace Chimera.Framework.Routing.Default.Tests.FluentConfigTests.HandlerTests
{
    public class RouteRegistrationTests
    {
        protected void RegisterHandlers()
        {
            var locator = new StructureMapLocator();

            new LocatorConfig(locator)
                .SetupDefaultConventions()
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(typeof (RoutingEngine)));

            Locator.SetImplementation(locator);

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

            var routingEngine = Locator.Get<IRoutingEngine>();
            routingEngine.GetRoutes().Count().ShouldBe(2);
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