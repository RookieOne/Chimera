using System;
using System.Collections.Generic;
using System.Reflection;
using Chimera.Default.Conventions;
using Chimera.Default.Routing;
using Chimera.Fluent.Configs;
using Chimera.Framework.Errors;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.InversionOfControl.Conventions;
using Chimera.Framework.Logging;
using Chimera.Framework.Routing;
using Chimera.Framework.ViewPresenters;
using Chimera.Framework.Views;

namespace Chimera.Fluent
{
    public class Configuration
    {
        Configuration(IChimeraContainer container)
        {
            _container = container;
            _configurators = new List<IConfig>();
            _configurators.Add(new LoggingConfig());
            _configurators.Add(new ViewModelConfig());
            _configurators.Add(new ViewConfig());
            _configurators.Add(new ViewPresenterConfig());
            _configurators.Add(new ControllerConfig());
            _configurators.Add(new ErrorsConfig());
            _configurators.Add(new ListenerConfig());   

            container.RegisterSingleton<IRoutingEngine, RoutingEngine>();
            var routingEngine = container.Get<IRoutingEngine>();

            AddConventionProcessors(routingEngine);

            _configurators.ForEach(c => c.InitializeContainer(_container));
        }

        readonly List<IConfig> _configurators;
        readonly IChimeraContainer _container;

        void AddConventionProcessors(IRoutingEngine engine)
        {
            engine.AddProcessor(new OnSuccessClose());
        }

        public static Configuration Default(IChimeraContainer container)
        {
            IoC.SetImplementation(container);

            return new Configuration(container);
        }

        public Configuration Register(Assembly assembly)
        {
            new DefaultConvention().Configure(_container, assembly);
            _configurators.ForEach(c => c.Register(assembly));
            return this;
        }

        public Configuration DefaultShowAs(string showAs)
        {
            var viewProcessor = _container.Get<IViewProcessor>();
            viewProcessor.DefaultShowAs(showAs);
            return this;
        }

        public Configuration SetViewBinder(IViewBinder binder)
        {
            var viewProcessor = _container.Get<IViewProcessor>();
            viewProcessor.SetBinder(binder);
            return this;
        }

        public Configuration SetErrorPresenter<T>() where T : IErrorPresenter
        {
            _container.RegisterSingleton(typeof(IErrorPresenter), typeof(T));

            var presenter = _container.Get<IErrorPresenter>();

            var processor = _container.Get<IErrorPresenterProcessor>();
            processor.SetPresenter(presenter);            

            return this;
        }

        public Configuration AddPresenter<T>() where T : IPresenterProcessor
        {
            var routingEngine = _container.Get<IRoutingEngine>();
            var presenter = Activator.CreateInstance<T>();
            routingEngine.AddProcessor(presenter);

            return this;
        }

        public Configuration AddLogger(ILogger logger)
        {
            var processor = _container.Get<ILoggingProcessor>();            
            processor.AddLogger(logger);
            return this;
        }
    }
}