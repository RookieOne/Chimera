using Chimera.Default.Routing;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;
using Chimera.Framework.ViewPresenters;

namespace Chimera.Default.ViewPresenters
{
    public class ViewPresenterProcessor : IViewPresenterProcessor
    {
        public bool CanProcess(IRoute route)
        {
            return route.Contains(KnownParameters.View)
                   && route.Contains(KnownParameters.ShowAs);
        }

        public IRouteResult Process(IRoute route)
        {
            var view = route[KnownParameters.View];
            var showAs = route[KnownParameters.ShowAs].ToString();

            var next = new Route("show", showAs)
                .AddParameter(KnownParameters.View, view);

            return new RouteResult(route).Next(next);
        }
    }
}