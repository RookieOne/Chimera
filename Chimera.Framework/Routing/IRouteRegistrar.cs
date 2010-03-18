using System.Collections.Generic;
using System.Reflection;

namespace Chimera.Framework.Routing
{
    public interface IRouteRegistrar<T>
    {
        IDictionary<IRouteSignature, T> GetSignatures(Assembly assembly);
    }
}