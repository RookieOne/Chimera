using System.Linq;
using System.Reflection;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.InversionOfControl.Conventions;

namespace Chimera.Routing.FluentConfig.Tests.ControllerTests
{
    public class ControllersAreSingletonsConvention : IConvention
    {
        public void Configure(IChimeraContainer ioc, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Controller"));

            foreach (var controllerType in types)
            {
                ioc.RegisterSingleton(controllerType, controllerType);
            }
        }
    }
}