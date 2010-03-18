using Chimera.Framework.Routing;

namespace Chimera.Default.Routing
{
    public class EndRouteResult : RouteResult
    {
        public EndRouteResult(IRoute route) : base(route)
        {
            Next(new EndRoute());
        }
    }
}