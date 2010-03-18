using System.Collections.Generic;
using Chimera.Framework.Routing;

namespace Chimera.Framework.Errors
{
    public interface IErrorPresenter
    {
        void Show(IRoute route, IEnumerable<IError> errors);
    }
}