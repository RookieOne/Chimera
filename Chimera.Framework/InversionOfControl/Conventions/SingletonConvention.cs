using System.Linq;
using System.Reflection;
using Chimera.Framework.Extensions;

namespace Chimera.Framework.InversionOfControl.Conventions
{
    public class SingletonConvention : IConvention
    {
        public void Configure(IChimeraContainer ioc, Assembly assembly)
        {
            var typesToRegister = assembly.GetTypes().Where(t => t.HasAttribute<SingletonAttribute>());

            foreach (var concreteType in typesToRegister)
            {
                var interfaceType = concreteType.GetAttribute<SingletonAttribute>().Type;
                ioc.RegisterSingleton(interfaceType, concreteType);
            }
        }
    }
}