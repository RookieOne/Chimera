using System.Collections.Generic;

namespace Chimera.Framework.Routing.Default
{
    public class Route : IRoute
    {
        public Route(string action, string resource)
        {
            Action = action;
            Resource = resource;
            Parameters = new Dictionary<string, object>();
        }

        public string Action { get; private set; }
        public string Resource { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; }

        public Route AddParameter(string key, object value)
        {
            Parameters.Add(key, value);
            return this;
        }
    }
}