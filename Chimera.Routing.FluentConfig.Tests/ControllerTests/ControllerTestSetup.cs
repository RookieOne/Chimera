using System.Reflection;
using Chimera.Framework.IoC.StructureMap;
using Chimera.Framework.Locators;
using Chimera.Routing.FluentConfig;

namespace Chimera.Routing.FluentConfig.Tests.ControllerTests
{
    public class ControllerTestSetup
    {
        protected void RegisterControllers()
        {
            var locator = new StructureMapLocator();

            new LocatorConfig(locator)
                .SetupDefaultConventions()
                .AddConvention(new ControllersAreSingletonsConvention())
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(typeof (RoutingEngine)))
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(this.GetType()));

            Locator.SetImplementation(locator);

            RegisterRoutes
                .FromAssembly(Assembly.GetAssembly(this.GetType()))
                .FromTypes(t => t.Name.EndsWith("Controller"))
                .UnderResourceName(t => t.Name.Replace("Controller", ""))
                .AllPublicMethods();
        }
    }
}