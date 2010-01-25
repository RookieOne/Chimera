using System;
using System.Collections.Generic;

namespace Chimera.Framework.Routing
{
    public interface IRoutingEngine
    {
        Action<IRoute> Resolve(IRoute route);
        IRoutingEngine Register(IRouteSignature route, Action<IRoute> mappedAction);
        IEnumerable<IRouteSignature> GetRouteSignatures();
    }
}