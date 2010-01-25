using System.Reflection;

namespace Chimera.Framework.Routing.FluentConfig
{
    public class RegisterRoutes
    {
        public static FromAssemblyConfig FromAssembly(Assembly assembly)
        {
            return new FromAssemblyConfig(assembly);
        }
    }
}