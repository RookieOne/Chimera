using Chimera.Framework.Routing;

namespace Chimera.Framework.Controllers
{
    public interface IControllerFactory
    {
        IController CreateController(IRoute route);
    }
}