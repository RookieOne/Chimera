using Chimera.Framework.Routing;

namespace Chimera.Framework.ViewModels
{
    public interface IViewModelEngine
    {
        object CreateViewModel(IRoute route);
    }
}