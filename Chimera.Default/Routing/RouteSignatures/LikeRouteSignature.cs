using System.Collections.Generic;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;
using System.Linq;

namespace Chimera.Default.Routing.RouteSignatures
{
    public class LikeRouteSignature : IRouteSignature
    {
        public LikeRouteSignature(IRoute route)
            : this(route.Action, route.Resource)
        {
        }

        public LikeRouteSignature(string action, string resource)
        {
            _action = action.ToLower();
            _resource = resource.ToLower();
            _with = new List<string>();
            _without= new List<string>();
        }

        public LikeRouteSignature WithParameter(string name)
        {
            _with.Add(name);
            return this;
        }

        public LikeRouteSignature WithoutParameter(string name)
        {
            _without.Add(name);
            return this;
        }
        
        string _action;
        List<string> _with;
        List<string> _without;
        string _resource;

        public bool Matches(IRoute route)
        {
            if (_action != route.Action)
                return false;

            if (_resource != route.Resource)
                return false;

            foreach(var parameter in _with)
            {
                if (!route.Parameters.Keys.Contains(parameter))
                    return false;
            }

            foreach (var parameter in _without)
            {
                if (route.Parameters.Keys.Contains(parameter))
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            return "{0} {1}".FormatWith(_action, _resource);
        }
    }
}