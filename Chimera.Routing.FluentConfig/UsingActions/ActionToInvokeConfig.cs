using System;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.RouteSignatures;

namespace Chimera.Routing.FluentConfig
{
    public class ActionToInvokeConfig
    {
        public ActionToInvokeConfig(string action, Func<IRoute, bool> func)
        {
            _action = action;
            _func = func;
        }

        readonly string _action;
        readonly Func<IRoute, bool> _func;

        public void Then(Action<IRoute> action)
        {
            var signature = new FuncRouteSignature(r => r.Action == _action && _func(r));

            IoC.Get<IRoutingEngine>().Register(signature, action);
        }
    }
}