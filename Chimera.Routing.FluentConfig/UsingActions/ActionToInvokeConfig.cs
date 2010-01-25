using System;
using Chimera.Framework.Routing;

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
            //var routingEngine = IoC.Get<IRoutingEngine>().Register()
        }
    }
}