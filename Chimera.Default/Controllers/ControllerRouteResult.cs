using Chimera.Default.Routing;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Controllers
{
    public class ControllerRouteResult : RouteResult
    {
        public ControllerRouteResult(IRoute route, object controller)
        {
            var result = route as IRouteResult ?? new RouteResult(route);
            CopyFrom(result);

            AddHistory(route);

            var nextRoute = new Route(route);
            nextRoute.AddParameter(KnownParameters.Controller, controller);

            Next(nextRoute);
        }
    }
}