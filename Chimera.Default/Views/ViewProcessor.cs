using Chimera.Default.Routing;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;
using Chimera.Framework.Views;

namespace Chimera.Default.Views
{
    public class ViewProcessor : RegisteredRouteProcessor, IViewProcessor
    {
        public ViewProcessor(IViewEngine engine)
            : base("View Processor")
        {
            _engine = engine;
        }

        readonly IViewEngine _engine;
        IViewBinder _binder;
        string _defaultShowAs;

        public override IRouteResult Process(IRoute route)
        {
            var view = _engine.CreateView(route);

            string showAs = _defaultShowAs;

            if (route.Contains(KnownParameters.ShowAs))
            {
                showAs = route[KnownParameters.ShowAs].ToString();
            }

            var result = new ViewRouteResult(route, view, showAs);            

            if (_binder != null)
            {
                _binder.Bind(result);
            }

            return result;
        }

        public void DefaultShowAs(string showAs)
        {
            _defaultShowAs = showAs;
        }

        public void SetBinder(IViewBinder binder)
        {
            _binder = binder;
        }
    }
}