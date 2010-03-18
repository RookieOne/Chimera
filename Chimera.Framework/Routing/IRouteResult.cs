using System.Collections.Generic;

namespace Chimera.Framework.Routing
{
    public interface IRouteResult : IRoute
    {
        bool Success { get; }
        string Message { get; }
        IEnumerable<IRoute> History { get; }
        IRouteResult Next(IRoute route);
    }
}