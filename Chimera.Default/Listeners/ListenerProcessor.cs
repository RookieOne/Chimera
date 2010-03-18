using Chimera.Framework.Listeners;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Framework.Routing.Extensions;

namespace Chimera.Default.Listeners
{
    public class ListenerProcessor : IListenerProcessor
    {
        public bool CanProcess(IRoute route)
        {
            return route.Contains(KnownParameters.Listener)
                   && route.DoesNotContain(KnownParameters.ProcessedByListener);
        }

        public IRouteResult Process(IRoute route)
        {
            var listener = route[KnownParameters.Listener] as IListener;

            var result = listener.Execute(route)
                .AddParameter(KnownParameters.ProcessedByListener, true);

            return result as IRouteResult;
        }
    }
}