using System.Reflection;

namespace Chimera.Framework.Locators.Conventions
{
    public class DefaultConvention : IConvention
    {
        public void Configure(ILocator locator, Assembly assembly)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var typeName = type.Name;
                var interfaceName = "I" + typeName;
                var interfaceType = type.GetInterface(interfaceName);

                if (interfaceType != null)
                    locator.Register(interfaceType, type);
            }
        }
    }
}