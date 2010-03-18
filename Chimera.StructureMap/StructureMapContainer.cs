using System;
using Chimera.Framework.InversionOfControl;
using StructureMap;

namespace Chimera.StructureMap
{
    public class StructureMapContainer : IChimeraContainer
    {
        public StructureMapContainer()
        {
            Container = new Container();
        }

        public Container Container { get; private set; }

        public T Get<T>()
        {
            return Container.GetInstance<T>();
        }

        public object Get(Type type)
        {
            return Container.GetInstance(type);
        }

        public void Register(Type interfaceType, Type concreteType)
        {
            Container.Configure(x => x.For(interfaceType).Use(concreteType));
        }

        public void RegisterSingleton(Type interfaceType, Type concreteType)
        {
            this.GetType().GetMethod("GenericRegisterSingleton")
                .MakeGenericMethod(new[] {interfaceType, concreteType})
                .Invoke(this, null);
        }

        public void GenericRegisterSingleton<I, C>() where C : I
        {
            Container.Configure(x => x.For<I>().Singleton().Use<C>());
        }
    }
}