using System.Collections.Generic;
using Chimera.Framework.Errors;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Errors
{
    public static class RouteExtensions
    {
        public static IRoute AddError(this IRoute route, IError error)
        {
            if (!route.Contains(KnownParameters.Errors))
                route.AddParameter(KnownParameters.Errors, new List<IError>());

            var errors = route[KnownParameters.Errors] as List<IError>;
            errors.Add(error);

            return route;
        }

        public static IRoute AddError(this IRoute route, string errorMessage)
        {
            return route.AddError(new Error(errorMessage));
        }
    }
}