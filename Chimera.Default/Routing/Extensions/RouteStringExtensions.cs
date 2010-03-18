using System.Collections.Generic;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using System.Linq;

namespace Chimera.Default.Routing.Extensions
{
    public static class RouteStringExtensions
    {
        public static void Send(this string s)
        {
            var engine = IoC.Get<IRoutingEngine>();

            var route = s.ToRoute();

            engine.Process(route);
        }

        public static IRoute ToRoute(this string s)
        {
            var words = s.Split(' ');

            var action = words[0];
            var resource = words[1];

            var route = new Route(action, resource);

            var parameters = words.Skip(2);

            foreach(var parameterString in parameters)
            {
                var key = parameterString.Split(':')[0];
                var value = parameterString.Split(':')[1];
                value = value.Replace("\'", "");

                route.AddParameter(key, value);
            }

            return route;
        }
    }
}