using Chimera.Default.Utilities;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Listeners;
using Chimera.Framework.Routing;

namespace Chimera.Default.Listeners
{
    public class ListenerFactory : TypedEngine, IListenerFactory
    {
        public IListener CreateListener(IRoute route)
        {
            var listenerType = GetTypeFor(route);

            return IoC.Get(listenerType) as IListener;
        }
    }
}