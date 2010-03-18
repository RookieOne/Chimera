using System.Reflection;
using Chimera.Default.ViewPresenters;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Framework.ViewPresenters;

namespace Chimera.Fluent.Configs
{
    public class ViewPresenterConfig : IConfig
    {
        public void InitializeContainer(IChimeraContainer container)
        {
            container.RegisterSingleton<IViewPresenterProcessor, ViewPresenterProcessor>();

            var engine = container.Get<IRoutingEngine>();
            var processor = container.Get<IViewPresenterProcessor>();
            engine.AddProcessor(processor);
        }

        public void Register(Assembly assembly)
        {
            // do nothing
        }
    }
}