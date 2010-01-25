using System.Collections.Generic;
using System.Reflection;
using Chimera.Framework.InversionOfControl.Conventions;

namespace Chimera.Framework.InversionOfControl
{
    public class IocConfig
    {
        public IocConfig(IChimeraContainer ioc)
        {
            _ioc = ioc;
            _conventions = new List<IConvention>();
            SetupDefaultConventions();
        }

        readonly IChimeraContainer _ioc;

        List<IConvention> _conventions;

        public IocConfig SetupDefaultConventions()
        {
            _conventions = new List<IConvention>();
            _conventions.Add(new DefaultConvention());
            _conventions.Add(new SingletonConvention());
            return this;
        }

        public IocConfig AddConvention(IConvention convention)
        {
            _conventions.Add(convention);
            return this;
        }

        public IocConfig ConfigureWithConventionsFromAssembly(Assembly assembly)
        {
            foreach (var convention in _conventions)
            {
                convention.Configure(_ioc, assembly);
            }
            return this;
        }
    }
}