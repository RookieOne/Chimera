using Chimera.Framework.Routing;

namespace Chimera.Framework.Errors
{
    public interface IErrorPresenterProcessor : IRouteProcessor
    {
        void SetPresenter(IErrorPresenter presenter);
    }
}