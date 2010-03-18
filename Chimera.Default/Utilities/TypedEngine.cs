using System;
using System.Collections.Generic;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Utilities
{
    public abstract class TypedEngine : IRegisterRoutes<Type>
    {
        protected TypedEngine()
        {
            Registry = new Dictionary<IRouteSignature, Type>();
        }

        public Dictionary<IRouteSignature, Type> Registry { get; set; }

        public void Register(Type type, IRouteSignature routeSignature)
        {
            Registry.Add(routeSignature, type);
        }

        public Type GetTypeFor(IRoute route)
        {            
            foreach (var routeSignature in Registry.Keys)
            {
                if (routeSignature.Matches(route))
                    return Registry[routeSignature];
            }

            return null;
        }
    }
}