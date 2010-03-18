using Chimera.Framework.Routing;

namespace Chimera.Framework.Controllers
{
    public interface IController
    {
        IRouteResult Execute(IRoute route);
    }
}