using Chimera.Default.Routing;
using Chimera.Framework.Routing;

namespace Chimera.Default.ViewModels
{
    public class ViewModelRouteResult : RouteResult
    {
        public ViewModelRouteResult(IRoute route, object viewModel)
        {
            var result = route as IRouteResult ?? new RouteResult(route);
            CopyFrom(result);

            AddHistory(route);

            var nextRoute = new Route(route);
            nextRoute.AddParameter("ViewModel", viewModel);

            Next(nextRoute);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}