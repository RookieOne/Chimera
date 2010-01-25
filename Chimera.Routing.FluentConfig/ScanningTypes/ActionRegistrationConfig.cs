using System;
using System.Collections.Generic;
using System.Reflection;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;

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

                    var route = IoC.Get<IRouteBuilder>()
                        .StartRoute(actionName, resourceName)
                        .AddAllParametersFrom(method)
                        .Build();

                    IoC.Get<IRoutingEngine>()
                        .Register(route, r => InvokeMethod(method, r));
                }
            }
        }

        void InvokeMethod(MethodInfo method, IRoute route)
        {
            var instance = Locator.Get(method.DeclaringType);

            method.Invoke(instance, route.GetParametersFor(method));
        }
    }
}