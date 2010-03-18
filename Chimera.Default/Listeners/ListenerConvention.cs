using System.Linq;
using System.Reflection;
using Chimera.Framework.Extensions;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.InversionOfControl.Conventions;
using Chimera.Framework.Listeners;

namespace Chimera.Default.Listeners
{
    public class ListenerConvention : IConvention
    {
        public void Configure(IChimeraContainer ioc, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.CanBeCastTo<IListener>());

            foreach (var t in types)
                ioc.RegisterSingleton(t, t);
        }
    }
}