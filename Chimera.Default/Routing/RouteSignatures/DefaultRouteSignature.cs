using System.Collections.Generic;
using System.Linq;
using Chimera.Framework.Routing;

namespace Chimera.Default.Routing.RouteSignatures
{
    public class DefaultRouteSignature : IRouteSignature
    {
        public DefaultRouteSignature(string action, string resource, string[] parameters)
        {
            _action = action;
            _resource = resource;
            _parameters = parameters;
        }

        public DefaultRouteSignature(string action, string resource)
        {
            _action = action;
            _resource = resource;
            _parameters = new List<string>().ToArray();
        }

        readonly string _action;
        readonly string[] _parameters;
        readonly string _resource;

        public bool Matches(IRoute route)
        {
            if (_resource.ToLower() != route.Resource.ToLower())
                return false;

            if (_action.ToLower() != route.Action.ToLower())
                return false;

            if (_parameters == null && route.Parameters.Keys.Count != 0)
                return false;

            if (_parameters == null && route.Parameters.Keys.Count == 0)
                return true;

            if (_parameters.Except(route.Parameters.Keys).Count() != 0)
                return false;

            return true;
        }
    }
}