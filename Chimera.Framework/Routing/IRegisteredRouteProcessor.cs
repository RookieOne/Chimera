using System.Collections.Generic;

namespace Chimera.Framework.Routing
{
    public interface IRegisteredRouteProcessor : IRouteProcessor
    {
        void Register(IRouteSignature routeSignature);
        void Register(IEnumerable<IRouteSignature> signatures);
    }
}