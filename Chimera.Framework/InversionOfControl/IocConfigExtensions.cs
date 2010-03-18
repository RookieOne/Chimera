using System.Reflection;

namespace Chimera.Framework.InversionOfControl
{
    public static class IocConfigExtensions
    {
        public static IocConfig ConfigureWithConventionsFromAssemblyWith<T>(this IocConfig config)
        {
            config.ConfigureWithConventionsFromAssembly(Assembly.GetAssembly(typeof (T)));
            return config;
        }
    }
}