using System.Collections.Generic;
using Chimera.Default.Routing;
using Chimera.Framework.Errors;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Errors
{
    public class ErrorPresenterProcessor : IErrorPresenterProcessor
    {
        IErrorPresenter _presenter;

        public bool CanProcess(IRoute route)
        {
            return route.Resource.Matches("errors");
        }

        public IRouteResult Process(IRoute route)
        {
            if (_presenter == null)
                return new EndRouteResult(route);

            if (!route.Contains(KnownParameters.Errors))
                throw new NoErrorsFoundToShowException(route);

            var errors = route[KnownParameters.Errors] as IEnumerable<IError>;
            _presenter.Show(route, errors);

            return new EndRouteResult(route);
        }

        public void SetPresenter(IErrorPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}