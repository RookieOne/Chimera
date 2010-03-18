using Chimera.Framework.Routing;

namespace Chimera.Framework.Views
{
    public interface IViewEngine
    {
        object CreateView(IRoute route);
    }
}