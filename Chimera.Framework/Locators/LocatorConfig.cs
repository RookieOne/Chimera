using System.Collections.Generic;
using System.Reflection;
using Chimera.Framework.Locators.Conventions;

namespace Chimera.Framework.Locators
{
    public class LocatorConfig
    {
        readonly ILocator _locator;

        public LocatorConfig(ILocator locator)
        {
            _locator = locator;
            _conventions = new List<IConvention>();
            SetupDefaultConventions();
        }

        List<IConvention> _conventions;

        public LocatorConfig SetupDefaultConventions()
        {
            _conventions = new List<IConvention>();
            _conventions.Add(new DefaultConvention());
            _conventions.Add(new SingletonConvention());
            return this;
        }

        public LocatorConfig AddConvention(IConvention convention)
        {
            _conventions.Add(convention);
            return this;
        }

        public LocatorConfig ConfigureWithConventionsFromAssembly(Assembly assembly)
        {
            foreach(var convention in _conventions)
            {
                convention.Configure(_locator, assembly);
            }
            return this;
        }
    }
}