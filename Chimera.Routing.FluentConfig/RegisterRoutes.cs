using System.Reflection;

namespace Chimera.Routing.FluentConfig
{
    public class RegisterRoutes
    {
        public static FromAssemblyConfig FromAssembly(Assembly assembly)
        {
            return new FromAssemblyConfig(assembly);
        }

        public static ForActionConfig For(string action)
        {
            return new ForActionConfig(action);
        }
    }
}