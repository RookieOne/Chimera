using System.Collections.Generic;
using System.Linq;
using Chimera.Framework.Routing;

namespace Chimera.Default.Routing
{
    public abstract class RegisteredRouteProcessor : IRouteProcessor
    {
        protected RegisteredRouteProcessor(string name)
        {
            _name = name;
            _signatures = new List<IRouteSignature>();
        }

        readonly string _name;
        readonly List<IRouteSignature> _signatures;

        public bool CanProcess(IRoute route)
        {
            return _signatures.Any(s => s.Matches(route))
                   && CanProcessFilter(route);
        }

        public virtual bool CanProcessFilter(IRoute route)
        {
            return true;
        }

        public abstract IRouteResult Process(IRoute route);

        public void Register(IRouteSignature routeSignature)
        {
            _signatures.Add(routeSignature);
        }

        public void Register(IEnumerable<IRouteSignature> signatures)
        {
            _signatures.Union(signatures);
        }
    }
}