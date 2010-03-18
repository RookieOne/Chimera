using System.Reflection;
using Chimera.Default.Logging;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Logging;
using Chimera.Framework.Routing;

namespace Chimera.Fluent.Configs
{
    public class LoggingConfig : IConfig
    {
        public void InitializeContainer(IChimeraContainer container)
        {
            container.RegisterSingleton<ILoggingProcessor, LoggingProcessor>();

            var processor = container.Get<ILoggingProcessor>();
            processor.AddLogger(new InMemoryLogger());

            var engine = container.Get<IRoutingEngine>();
            engine.AddProcessor(processor);
        }

        public void Register(Assembly assembly)
        {
            // do nothing
        }
    }
}