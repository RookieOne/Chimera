using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Utilities
{
    public class ConventionRegistrar<T> : IConventionRegistrar<T>
    {
        public ConventionRegistrar(IRegisteredRouteProcessor processor, IRegisterRoutes<T> registersRoutes)
        {
            _processor = processor;
            _registersRoutes = registersRoutes;
            _registrars = new List<IRouteRegistrar<T>>();
        }

        readonly IRegisteredRouteProcessor _processor;
        readonly IRegisterRoutes<T> _registersRoutes;
        readonly List<IRouteRegistrar<T>> _registrars;

        public void Register(Assembly assembly)
        {
            foreach (var registrar in _registrars)
            {
                var maps = registrar.GetSignatures(assembly)
                    .Select(kv => new {Type = kv.Value, Signature = kv.Key});

                foreach (var map in maps)
                {
                    _registersRoutes.Register(map.Type, map.Signature);
                    _processor.Register(map.Signature);
                }
            }
        }

        public void Add(IRouteRegistrar<T> registrar)
        {
            _registrars.Add(registrar);
        }
    }
}