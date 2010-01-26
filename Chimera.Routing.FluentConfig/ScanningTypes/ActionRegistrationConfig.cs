using System;
using System.Collections.Generic;
using System.Reflection;
using Chimera.Framework.Extensions;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.RouteSignatures;

namespace Chimera.Routing.FluentConfig
{
    public class ActionRegistrationConfig
    {
        public ActionRegistrationConfig(IEnumerable<Tuple<string, Type>> pairings)
        {
            _pairings = pairings;
        }

        readonly IEnumerable<Tuple<string, Type>> _pairings;

        public void AllPublicMethods()
        {
            foreach (var pair in _pairings)
            {
                var type = pair.Item2;

                var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

                foreach (var method in methods)
                {
                    var resourceName = pair.Item1;
                    var actionName = method.Name;

                    var routeSignature = new DefaultRouteSignature(actionName, resourceName, method.GetParameterNames());

                    IoC.Get<IRoutingEngine>()
                        .Register(routeSignature, r => InvokeMethod(method, r));
                }
            }
        }

        void InvokeMethod(MethodInfo method, IRoute route)
        {
            var instance = IoC.Get(method.DeclaringType);

            method.Invoke(instance, route.GetParametersFor(method));
        }
    }
}