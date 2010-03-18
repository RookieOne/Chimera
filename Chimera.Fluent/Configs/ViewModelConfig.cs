using System.Reflection;
using Chimera.Default.ViewModels;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Framework.ViewModels;

namespace Chimera.Fluent.Configs
{
    public class ViewModelConfig : IConfig
    {
        IRegistrar _registrar;

        public void InitializeContainer(IChimeraContainer container)
        {
            container.RegisterSingleton<IViewModelEngine, ViewModelEngine>();
            container.RegisterSingleton<IViewModelProcessor, ViewModelProcessor>();

            var engine = container.Get<IRoutingEngine>();
            var processor = container.Get<IViewModelProcessor>();
            engine.AddProcessor(processor);

            var viewModelEngine = container.Get<IViewModelEngine>();

            ConfigureRegistrar(viewModelEngine, processor);
        }

        public void Register(Assembly assembly)
        {
            _registrar.Register(assembly);
        }

        void ConfigureRegistrar(IViewModelEngine engine, IViewModelProcessor processor)
        {
            var r = new ViewModelRegistrar(processor, engine);
            r.Add(new ReflectionViewModelRegistrar());

            _registrar = r;
        }
    }
}