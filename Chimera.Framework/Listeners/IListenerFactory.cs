using Chimera.Framework.Routing;

namespace Chimera.Framework.Listeners
{
    public interface IListenerFactory
    {
        IListener CreateListener(IRoute route);
    }
}