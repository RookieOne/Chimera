using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Default.Routing;
using Chimera.Default.Routing.Extensions;
using Chimera.Framework.Extensions;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Listeners;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;

namespace Chimera.Default.Listeners
{
    public class Listener : IListener
    {
        public IRouteResult Execute(IRoute route)
        {
            var method = GetMethod(route);

            var parameters = GetParameters(route, method);

            object result = method.Invoke(this, parameters);            

            var next = CreateRoute(result);

            if (next == null)
                return new EndRouteResult(route);

            var routeResult = new RouteResult(route);
            routeResult.Next(next);
            return routeResult;
        }

        IRoute CreateRoute(object returnObject)
        {
            if (returnObject == null)
                return null;

            if (returnObject.GetType().CanBeCastTo<IRoute>())
            {
                return returnObject as IRoute;
            }

            if (returnObject.GetType() == typeof (string))
            {
                return returnObject.ToString().ToRoute();
            }

            return null;
        }

        object[] GetParameters(IRoute route, MethodInfo method)
        {
            var parameters = new List<object>();
            foreach (var p in method.GetParameters())
            {
                if (route.Contains(p.Name))
                {
                    parameters.Add(route[p.Name]);
                }
                else
                {
                    parameters.Add(IoC.Get(p.ParameterType));
                }
            }

            return parameters.ToArray();
        }

        MethodInfo GetMethod(IRoute route)
        {
            return GetType().GetActionMethods()
                .First(m => m.Name.Matches("On{0}{1}".FormatWith(route.Action, route.Resource)));
        }
    }
}