using Chimera.Default.Routing;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Framework.ViewModels;
using Chimera.Framework.Routing.Extensions;

namespace Chimera.Default.ViewModels
{
    public class ViewModelProcessor : RegisteredRouteProcessor, IViewModelProcessor
    {
        public ViewModelProcessor(IViewModelEngine engine)
            : base("ViewModel Processor")
        {
            _engine = engine;
        }

        readonly IViewModelEngine _engine;

        public override bool CanProcessFilter(IRoute route)
        {
            return route.DoesNotContain(KnownParameters.ViewModel);
        }

        public override IRouteResult Process(IRoute route)
        {
            var viewModel = _engine.CreateViewModel(route);

            return new ViewModelRouteResult(route, viewModel);
        }
    }
}