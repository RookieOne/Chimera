using System.Linq;
using System.Reflection;

namespace Chimera.Framework.InversionOfControl.Conventions
{
    public class DefaultConvention : IConvention
    {
        public void Configure(IChimeraContainer ioc, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => !t.IsGenericType);

            foreach (var type in types)
            {
                var typeName = type.Name;
                var interfaceName = "I" + typeName;
                var interfaceType = type.GetInterface(interfaceName);

                if (interfaceType != null)
                    ioc.Register(interfaceType, type);
            }
        }
    }
}