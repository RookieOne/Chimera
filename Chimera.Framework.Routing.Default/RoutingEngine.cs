using System;
using System.Collections.Generic;
using System.Linq;
using Chimera.Framework.Extensions;
using Chimera.Framework.Locators.Conventions;

namespace Chimera.Framework.Routing.Default
{
    [Singleton(typeof (IRoutingEngine))]
    public class RoutingEngine : IRoutingEngine
    {
        public RoutingEngine()
        {
            _Routes = new Dictionary<IRoute, Action<IRoute>>();
        }

        readonly Dictionary<IRoute, Action<IRoute>> _Routes;

        public Action<IRoute> Resolve(IRoute route)
        {
            var key = _Routes.Keys.FirstOrDefault(k => k.IsSameRouteAs(route));

            return (key != null)
                       ? _Routes[key]
                       : r => Do.Nothing();
        }

        public IRoutingEngine Register(IRoute route, Action<IRoute> mappedAction)
        {
            _Routes.Add(route, mappedAction);
            return this;
        }

        public IEnumerable<IRoute> GetRoutes()
        {
            return _Routes.Keys.ToList();
        }
    }
}