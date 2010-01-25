using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Chimera.Framework.Extensions;

namespace Chimera.Framework.Locators.Conventions
{
    public class SingletonConvention : IConvention
    {
        public void Configure(ILocator locator, Assembly assembly)
        {
            var typesToRegister = assembly.GetTypes().Where(t => t.HasAttribute<SingletonAttribute>());

            foreach (var concreteType in typesToRegister)
            {
                var interfaceType = concreteType.GetAttribute<SingletonAttribute>().Type;
                locator.RegisterSingleton(interfaceType, concreteType);
            }
        }
    }
}
