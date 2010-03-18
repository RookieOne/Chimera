using Chimera.Default.Routing;
using Chimera.Framework.Listeners;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Listeners
{
    public class ListenerFactoryProcessor : RegisteredRouteProcessor, IListenerFactoryProcessor
    {
        public ListenerFactoryProcessor(IListenerFactory factory)
            : base("Listener Factory Processor")
        {
            _factory = factory;
        }

        readonly IListenerFactory _factory;

        public override bool CanProcessFilter(IRoute route)
        {
            return route.DoesNotContain(KnownParameters.Listener);
        }

        public override IRouteResult Process(IRoute route)
        {
            var listener = _factory.CreateListener(route);

            return new ListenerRouteResult(route, listener);
        }
    }
}