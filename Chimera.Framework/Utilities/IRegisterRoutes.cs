using Chimera.Framework.Routing;

namespace Chimera.Framework.Utilities
{
    public interface IRegisterRoutes<T>
    {
        void Register(T type, IRouteSignature routeSignature);
    }
}