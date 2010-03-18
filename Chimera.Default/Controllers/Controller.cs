using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Default.Routing;
using Chimera.Default.Routing.Extensions;
using Chimera.Default.ViewModels;
using Chimera.Framework.Controllers;
using Chimera.Framework.Extensions;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;

namespace Chimera.Default.Controllers
{
    public class Controller : IController
    {
        public IRouteResult Execute(IRoute route)
        {
            var method = GetMethod(route);

            var parameters = GetParameters(route, method);

            object result = method.Invoke(this, parameters);
           
            return CreateRoute(result, route);
        }

        IRouteResult CreateRoute(object returnObject, IRoute route)
        {
            if (returnObject == null)
                return new EndRouteResult(route); ;

            if (returnObject.GetType().CanBeCastTo<IRoute>())
            {
                var next = returnObject as IRoute;
                var routeResult = new RouteResult(route);
                routeResult.Next(next);
                return routeResult;
            }

            if (returnObject.GetType() == typeof (string))
            {
                var next = returnObject.ToString().ToRoute();
                var routeResult = new RouteResult(route);
                routeResult.Next(next);
                return routeResult;
            }            

            return new ViewModelRouteResult(route, returnObject);
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
                .First(m => m.Name.Matches(route.Action));
        }
    }
}