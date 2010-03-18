using System;
using Chimera.Default.Utilities;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Framework.ViewModels;

namespace Chimera.Default.ViewModels
{
    public class ViewModelEngine : TypedEngine, IViewModelEngine
    {
        public object CreateViewModel(IRoute route)
        {
            var type = GetTypeFor(route);

            if (type == null)
                return null;

            return IoC.Get(type);
        }
    }
}