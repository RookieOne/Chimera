using System.Reflection;
using Chimera.Default.Views;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Framework.Views;

namespace Chimera.Fluent.Configs
{
    public class ViewConfig : IConfig
    {
        IRegistrar _registrar;

        public void InitializeContainer(IChimeraContainer container)
        {
            container.RegisterSingleton<IViewEngine, ViewEngine>();
            container.RegisterSingleton<IViewProcessor, ViewProcessor>();

            var engine = container.Get<IRoutingEngine>();
            var processor = container.Get<IViewProcessor>();
            processor.DefaultShowAs("Window");
            engine.AddProcessor(processor);

            var viewEngine = container.Get<IViewEngine>();

            ConfigureRegistrar(viewEngine, processor);
        }

        public void Register(Assembly assembly)
        {
            _registrar.Register(assembly);
        }

        void ConfigureRegistrar(IViewEngine engine, IViewProcessor processor)
        {
            var r = new ViewRegistrar(processor, engine);
            r.Add(new ReflectionViewRegistrar());

            _registrar = r;
        }
    }
}