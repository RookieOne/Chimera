using System.Reflection;
using Chimera.Default.Errors;
using Chimera.Framework.Errors;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;

namespace Chimera.Fluent.Configs
{
    public class ErrorsConfig : IConfig
    {
        public void InitializeContainer(IChimeraContainer container)
        {
            container.RegisterSingleton<IErrorProcessor, ErrorProcessor>();
            container.RegisterSingleton<IErrorPresenterProcessor, ErrorPresenterProcessor>();

            var engine = container.Get<IRoutingEngine>();
            var processor = container.Get<IErrorProcessor>();
            engine.AddProcessor(processor);

            var presenterProcessor = container.Get<IErrorPresenterProcessor>();
            engine.AddProcessor(presenterProcessor);
        }

        public void Register(Assembly assembly)
        {
            // do nothing
        }
    }
}