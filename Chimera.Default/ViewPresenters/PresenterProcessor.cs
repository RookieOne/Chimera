using Chimera.Default.Routing;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Framework.ViewPresenters;

namespace Chimera.Default.ViewPresenters
{
    public abstract class PresenterProcessor : IPresenterProcessor
    {
        protected PresenterProcessor(string resource)
        {
            _resource = resource;
        }

        readonly string _resource;

        public bool CanProcess(IRoute route)
        {
            return route.Resource.Matches(_resource);
        }

        public IRouteResult Process(IRoute route)
        {
            var action = route.Action;
            
            if (action.Matches("show"))
            {
                Show(route[KnownParameters.View]);
            }

            if (action.Matches("close"))
            {
                Close(route[KnownParameters.View]);
            }                

            if (action.Matches("register"))
            {
                RegisterHost(route[KnownParameters.PresenterHost]);
            }

            return new EndRouteResult(route);
        }

        public abstract void RegisterHost(object host);
        public abstract void Show(object view);
        public abstract void Close(object view);
    }
}