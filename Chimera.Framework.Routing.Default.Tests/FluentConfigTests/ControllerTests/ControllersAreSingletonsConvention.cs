using System.Linq;
using System.Reflection;
using Chimera.Framework.Locators;
using Chimera.Framework.Locators.Conventions;

namespace Chimera.Framework.Routing.Default.Tests.FluentConfigTests.ControllerTests
{
    public class ControllersAreSingletonsConvention : IConvention
    {
        public void Configure(ILocator locator, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Controller"));

            foreach (var controllerType in types)
            {
                locator.RegisterSingleton(controllerType, controllerType);
            }
        }
    }
}