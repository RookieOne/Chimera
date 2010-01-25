using System;
using System.Collections.Generic;

namespace Chimera.Framework.Routing
{
    public interface IRoutingEngine
    {
        Action<IRoute> Resolve(IRoute route);
        IRoutingEngine Register(IRoute route, Action<IRoute> mappedAction);
        IEnumerable<IRoute> GetRoutes();
    }
}