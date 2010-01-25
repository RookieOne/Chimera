using System;

namespace Chimera.Routing.FluentConfig
{
    public class ForActionConfig
    {
        public ForActionConfig(string action)
        {
            _action = action;
        }

        public ActionToInvokeConfig If(Func<IRoute, bool> func)
        {
            return new ActionToInvokeConfig(_action, func);
        }

        readonly string _action;
    }
}