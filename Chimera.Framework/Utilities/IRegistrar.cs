using System.Reflection;

namespace Chimera.Framework.Utilities
{
    public interface IRegistrar
    {
        void Register(Assembly assembly);
    }
}