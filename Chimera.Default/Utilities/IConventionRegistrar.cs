using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Utilities
{
    public interface IConventionRegistrar<T> : IRegistrar
    {
        void Add(IRouteRegistrar<T> registrar);
    }
}