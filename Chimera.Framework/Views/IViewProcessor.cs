using Chimera.Framework.Routing;

namespace Chimera.Framework.Views
{
    public interface IViewProcessor : IRegisteredRouteProcessor
    {
        void DefaultShowAs(string showAs);
        void SetBinder(IViewBinder binder);
    }
}