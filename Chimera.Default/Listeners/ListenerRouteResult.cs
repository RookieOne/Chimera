using Chimera.Default.Routing;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Listeners
{
    public class ListenerRouteResult : RouteResult
    {
        public ListenerRouteResult(IRoute route, object listener)
        {
            var result = route as IRouteResult ?? new RouteResult(route);
            CopyFrom(result);

            AddHistory(route);

            var nextRoute = new Route(route);
            nextRoute.AddParameter(KnownParameters.Listener, listener);

            Next(nextRoute);
        }
    }
}