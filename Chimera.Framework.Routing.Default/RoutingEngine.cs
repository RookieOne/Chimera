using System;
using System.Collections.Generic;
using System.Linq;
using Chimera.Framework.Extensions;
using Chimera.Framework.InversionOfControl.Conventions;
using Chimera.Framework.Routing;

namespace Chimera.Routing.Default
{
    [Singleton(typeof (IRoutingEngine))]
    public class RoutingEngine : IRoutingEngine
    {
        public RoutingEngine()
        {
            _Routes = new Dictionary<IRouteSignature, Action<IRoute>>();
        }

        readonly Dictionary<IRouteSignature, Action<IRoute>> _Routes;

        public Action<IRoute> Resolve(IRoute route)
        {
            var key = _Routes.Keys.FirstOrDefault(k => k.Matches(route));

            return (key != null)
                       ? _Routes[key]
                       : r => Do.Nothing();
        }

        public IRoutingEngine Register(IRouteSignature route, Action<IRoute> mappedAction)
        {
            _Routes.Add(route, mappedAction);
            return this;
        }

        public IEnumerable<IRouteSignature> GetRouteSignatures()
        {
            return _Routes.Keys.ToList();
        }
    }
}