using Chimera.Default.Routing;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Framework.Routing.Extensions;

namespace Chimera.Default.Views
{
    public class ViewRouteResult : RouteResult
    {
        public ViewRouteResult(IRoute route, object view, string showAs)
        {
            var result = route as IRouteResult ?? new RouteResult(route);
            CopyFrom(result);

            AddHistory(route);

            var nextRoute = new Route(route);
            nextRoute.AddParameter(KnownParameters.View, view);

            if (nextRoute.DoesNotContain(KnownParameters.ShowAs))
                nextRoute.AddParameter(KnownParameters.ShowAs, showAs);

            Next(nextRoute);
        }
    }
}