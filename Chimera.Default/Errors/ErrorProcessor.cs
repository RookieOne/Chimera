using Chimera.Default.Routing;
using Chimera.Framework.Errors;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Errors
{
    public class ErrorProcessor : IErrorProcessor
    {
        public bool CanProcess(IRoute route)
        {
            return route.Contains(KnownParameters.Errors)
                   && !route.Resource.Matches("errors");
        }

        public IRouteResult Process(IRoute route)
        {
            var result = new RouteResult(route);

            var next = new Route("show", "errors")
                .CopyParameterFrom(route, KnownParameters.Errors);

            var view = route.Parameters[KnownParameters.ParentView];
            next.AddParameter(KnownParameters.View, view);

            result.Next(next);

            return result;
        }
    }
}