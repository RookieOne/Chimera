using System.Reflection;
using Chimera.Default.Controllers;
using Chimera.Framework.Controllers;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.InversionOfControl.Conventions;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Fluent.Configs
{
    public class ControllerConfig : IConfig
    {
        IRegistrar _registrar;
        IChimeraContainer _container;

        public void InitializeContainer(IChimeraContainer container)
        {
            _container = container;

            container.RegisterSingleton<IControllerFactory, ControllerFactory>();
            container.RegisterSingleton<IControllerFactoryProcessor, ControllerFactoryProcessor>();
            container.RegisterSingleton<IControllerProcessor, ControllerProcessor>();

            var engine = container.Get<IRoutingEngine>();
            var factoryProcessor = container.Get<IControllerFactoryProcessor>();
            engine.AddProcessor(factoryProcessor);

            var factory = container.Get<IControllerFactory>();

            ConfigureRegistrar(factory, factoryProcessor);

            var processor = container.Get<IControllerProcessor>();
            engine.AddProcessor(processor);
        }

        public void Register(Assembly assembly)
        {
            _registrar.Register(assembly);
            new ControllerConvention().Configure(_container, assembly);
        }

        void ConfigureRegistrar(IControllerFactory factory, IControllerFactoryProcessor processor)
        {
            var r = new ControllerRegistrar(processor, factory);
            r.Add(new ReflectionControllerRegistrar());

            _registrar = r;
        }
    }
}