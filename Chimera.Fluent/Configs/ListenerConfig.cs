using System.Reflection;
using Chimera.Default.Listeners;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.InversionOfControl.Conventions;
using Chimera.Framework.Listeners;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Fluent.Configs
{
    public class ListenerConfig : IConfig
    {
        IChimeraContainer _container;
        IRegistrar _registrar;

        public void InitializeContainer(IChimeraContainer container)
        {
            _container = container;

            container.RegisterSingleton<IListenerFactory, ListenerFactory>();
            container.RegisterSingleton<IListenerFactoryProcessor, ListenerFactoryProcessor>();
            container.RegisterSingleton<IListenerProcessor, ListenerProcessor>();

            var engine = container.Get<IRoutingEngine>();
            var factoryProcessor = container.Get<IListenerFactoryProcessor>();
            engine.AddProcessor(factoryProcessor);

            var factory = container.Get<IListenerFactory>();

            ConfigureRegistrar(factory, factoryProcessor);

            var processor = container.Get<IListenerProcessor>();
            engine.AddProcessor(processor);
        }

        public void Register(Assembly assembly)
        {
            _registrar.Register(assembly);
            new ListenerConvention().Configure(_container, assembly);
        }

        void ConfigureRegistrar(IListenerFactory factory, IListenerFactoryProcessor processor)
        {
            var r = new ListenerRegistrar(processor, factory);
            r.Add(new ReflectionListenerRegistrar());

            _registrar = r;
        }
    }
}