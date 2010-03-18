using System;
using Chimera.Default.Utilities;
using Chimera.Framework.Routing;
using Chimera.Framework.Views;

namespace Chimera.Default.Views
{
    public class ViewEngine : TypedEngine, IViewEngine
    {
        public object CreateView(IRoute route)
        {
            var type = GetTypeFor(route);

            if (type == null)
                return null;

            return Activator.CreateInstance(type);
        }
    }
}