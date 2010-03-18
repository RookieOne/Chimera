using Chimera.Framework.Routing;

namespace Chimera.Framework.Views
{
    public interface IViewBinder
    {
        void Bind(IRoute route);
    }
}