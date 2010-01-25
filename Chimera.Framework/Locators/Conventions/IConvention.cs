using System.Reflection;

namespace Chimera.Framework.Locators.Conventions
{
    public interface IConvention
    {
        void Configure(ILocator locator, Assembly assembly);
    }
}