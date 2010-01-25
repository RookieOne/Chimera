using System;

namespace Chimera.Framework.InversionOfControl
{
    public interface IChimeraContainer
    {
        T Get<T>();
        object Get(Type type);
        void Register(Type interfaceType, Type concreteType);
        void RegisterSingleton(Type interfaceType, Type concreteType);
    }
}