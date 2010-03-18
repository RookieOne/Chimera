using System;
using Chimera.Framework.Routing;

namespace Chimera.Default.Routing.RouteSignatures
{
    public class FuncRouteSignature : IRouteSignature
    {
        public FuncRouteSignature(Func<IRoute, bool> func)
        {
            _func = func;
        }

        readonly Func<IRoute, bool> _func;

        public bool Matches(IRoute route)
        {
            return _func(route);
        }
    }
}