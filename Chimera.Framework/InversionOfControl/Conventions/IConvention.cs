using System.Reflection;

namespace Chimera.Framework.InversionOfControl.Conventions
{
    public interface IConvention
    {
        void Configure(IChimeraContainer ioc, Assembly assembly);
    }
}