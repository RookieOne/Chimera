using Chimera.Default.Routing;
using Chimera.Framework.Controllers;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Controllers
{
    public class ControllerFactoryProcessor : RegisteredRouteProcessor, IControllerFactoryProcessor
    {
        public ControllerFactoryProcessor(IControllerFactory factory)
            : base("Controller Factory Processor")
        {
            _factory = factory;
        }

        readonly IControllerFactory _factory;

        public override bool CanProcessFilter(IRoute route)
        {
            return !route.Contains(KnownParameters.Controller);
        }

        public override IRouteResult Process(IRoute route)
        {
            var controller = _factory.CreateController(route);

            return new ControllerRouteResult(route, controller);
        }
    }
}