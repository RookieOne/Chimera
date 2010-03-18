using Chimera.Default.Utilities;
using Chimera.Framework.Controllers;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;

namespace Chimera.Default.Controllers
{
    public class ControllerFactory : TypedEngine, IControllerFactory
    {
        public IController CreateController(IRoute route)
        {
            var controllerType = GetTypeFor(route);

            return IoC.Get(controllerType) as IController;
        }
    }
}