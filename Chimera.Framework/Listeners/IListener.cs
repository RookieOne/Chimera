using Chimera.Framework.Routing;

namespace Chimera.Framework.Listeners
{
    public interface IListener
    {
        IRouteResult Execute(IRoute route);
    }
}