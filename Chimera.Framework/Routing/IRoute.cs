using System;
using System.Collections.Generic;

namespace Chimera.Framework.Routing
{
    public interface IRoute
    {
        string Action { get; }
        string Resource { get; }
        Dictionary<string, object> Parameters { get; }
        object this[string s] { get;}
        long Start { get; set; }
        long End { get; set; }
    }
}