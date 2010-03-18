using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chimera.Framework.Routing;

namespace Chimera.Default.Utilities
{
    public interface ITypedEngine
    {
        void Register(Type type, IRouteSignature routeSignature);
    }
}
