using System.Reflection;
using Chimera.Framework.InversionOfControl;

namespace Chimera.Fluent
{
    public interface IConfig
    {
        void InitializeContainer(IChimeraContainer container);
        void Register(Assembly assembly);
    }
}