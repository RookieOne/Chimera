using System.Linq;

namespace Chimera.Framework.Routing.RouteSignatures
{
    public class DefaultRouteSignature : IRouteSignature
    {
        public DefaultRouteSignature(string action, string resource, string[] parameters)
        {
            _action = action;
            _resource = resource;
            _parameters = parameters;
        }

        readonly string _action;
        readonly string[] _parameters;
        readonly string _resource;

        public bool Matches(IRoute route)
        {
            if (_resource != route.Resource)
                return false;

            if (_action != route.Action)
                return false;

            if (_parameters.Except(route.Parameters.Keys).Count() != 0)
                return false;

            return true;
        }
    }
}