using System;
using System.Linq;
using System.Reflection;

namespace Chimera.Routing.FluentConfig
{
    public class FromAssemblyConfig
    {
        public FromAssemblyConfig(Assembly assembly)
        {
            _assembly = assembly;
        }

        readonly Assembly _assembly;

        public FromTypesConfig FromTypes(Func<Type, bool> func)
        {
            var types = _assembly.GetTypes().Where(func);

            return new FromTypesConfig(types);
        }
    }
}