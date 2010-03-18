using System;
using System.Collections.Generic;
using Chimera.Framework.InversionOfControl;

namespace Chimera.Default.Tests.Utilities
{
    public class MockContainer : IChimeraContainer
    {
        public MockContainer()
        {
            _registry = new Dictionary<Type, Type>();
        }

        Dictionary<Type, Type> _registry;

        public T Get<T>()
        {
            var t = _registry[typeof(T)];
            return (T)Activator.CreateInstance(t);
        }

        public object Get(Type type)
        {
            var t = _registry[type];
            return Activator.CreateInstance(t);
        }

        public void Register(Type interfaceType, Type concreteType)
        {
            _registry.Add(interfaceType, concreteType);
        }

        public void RegisterSingleton(Type interfaceType, Type concreteType)
        {
            throw new NotImplementedException();
        }
    }
}