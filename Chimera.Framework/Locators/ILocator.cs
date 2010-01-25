using System;

namespace Chimera.Framework.Locators
{
    public interface ILocator
    {
        T Get<T>();
        object Get(Type type);
        void Register(Type interfaceType, Type concreteType);
        void RegisterSingleton(Type interfaceType, Type concreteType);
    }
}