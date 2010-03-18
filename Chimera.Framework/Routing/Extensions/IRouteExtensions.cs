using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Chimera.Framework.Extensions;
using Chimera.Framework.InversionOfControl;

namespace Chimera.Framework.Routing.Extensions
{
    public static class IRouteExtensions
    {
        public static object[] GetParametersFor(this IRoute route, MethodInfo method)
        {
            var parameterValues = new List<object>();
            foreach (var parameter in method.GetParameters())
            {
                parameterValues.Add(route.Parameters[parameter.Name]);
            }

            return parameterValues.ToArray();
        }

        public static bool RouteEquals(this IRoute r1, IRoute r2)
        {
            if (r1.Resource != r2.Resource)
                return false;
            if (r1.Action != r2.Action)
                return false;

            return true;
        }

        public static bool IsEnd(this IRoute r)
        {
            return string.IsNullOrEmpty(r.Action)
                   && string.IsNullOrEmpty(r.Resource);
        }

        public static string AsString(this IRoute r)
        {
            var sb = new StringBuilder()
                .AppendFormat("{0} ", r.Action)
                .AppendFormat("{0} ", r.Resource);

            foreach (var p in r.Parameters)
                sb.Append("{" + p.Key + "} ");

            return sb.ToString();
        }

        public static void Send(this IRoute r)
        {
            IoC.Get<IRoutingEngine>().Process(r);
        }


    }
}