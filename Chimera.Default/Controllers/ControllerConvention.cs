using System.Linq;
using System.Reflection;
using Chimera.Framework.Controllers;
using Chimera.Framework.Extensions;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.InversionOfControl.Conventions;

namespace Chimera.Default.Controllers
{
    public class ControllerConvention : IConvention
    {
        public void Configure(IChimeraContainer ioc, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.CanBeCastTo<IController>());

            foreach (var t in types)
                ioc.Register(t, t);
        }
    }
}