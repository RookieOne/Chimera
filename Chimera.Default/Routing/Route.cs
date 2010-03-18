using System;
using System.Collections.Generic;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;

namespace Chimera.Default.Routing
{
    public class Route : IRoute
    {
        public Route(string action, string resource)
        {
            Action = action;
            Resource = resource;
            Parameters = new Dictionary<string, object>();
        }

        public Route(IRoute route)
        {
            Action = route.Action;
            Resource = route.Resource;
            Parameters = new Dictionary<string, object>();
            route.Parameters.ForEach(kv => AddParameter(kv.Key, kv.Value));
        }

        public string Action { get; private set; }
        public string Resource { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; }
        public long Start { get; set; }
        public long End { get; set; }

        public object this[string s]
        {
            get { return Parameters[s]; }
        }


        public Route AddParameter(string key, object value)
        {
            Parameters.Add(key, value);
            return this;
        }

        public override string ToString()
        {
            return this.AsString();
        }
    }
}