using Chimera.Default.Routing;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Conventions
{
    public class OnSuccessClose : IRouteProcessor
    {
        public bool CanProcess(IRoute route)
        {
            return route.Action.Matches(KnownActions.Success);
        }

        public IRouteResult Process(IRoute route)
        {
            var showAs = route.Parameters[KnownParameters.ParentShowAs].ToString();
            var view = route.Parameters[KnownParameters.ParentView];

            var next = new Route("close", showAs);
            next.AddParameter(KnownParameters.View, view);

            var result = new RouteResult(route);
            result.Next(next);

            return result;
        }
    }
}