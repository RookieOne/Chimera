using System.Reflection;
using Chimera.Framework.InversionOfControl;
using Chimera.Routing.Default;
using Chimera.StructureMap;

namespace Chimera.Routing.FluentConfig.Tests.ControllerTests
{
    public class ControllerTestSetup
    {
        protected void RegisterControllers()
        {
            var locator = new StructureMapContainer();

            new IocConfig(locator)
                .SetupDefaultConventions()
                .AddConvention(new ControllersAreSingletonsConvention())
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(typeof (RoutingEngine)))
                .ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(this.GetType()));

            IoC.SetImplementation(locator);

            RegisterRoutes
                .FromAssembly(Assembly.GetAssembly(this.GetType()))
                .FromTypes(t => t.Name.EndsWith("Controller"))
                .UnderResourceName(t => t.Name.Replace("Controller", ""))
                .AllPublicMethods();
        }
    }
}