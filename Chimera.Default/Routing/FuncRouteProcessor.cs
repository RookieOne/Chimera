using System;
using Chimera.Framework.Routing;

namespace Chimera.Default.Routing
{
    public class FuncRouteProcessor : IRouteProcessor
    {
        public Func<IRoute, bool> _CanProcess = r => true;
        public Func<IRoute, IRouteResult> _Process = r => new RouteResult();

        public bool CanProcess(IRoute route)
        {
            return _CanProcess(route);
        }

        public IRouteResult Process(IRoute route)
        {
            return _Process(route);
        }
    }
}