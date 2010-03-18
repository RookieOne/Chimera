using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using Chimera.Framework.Errors;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Wpf.Adorners;

namespace Chimera.Wpf.Presenters
{
    public class ErrorPresenter : IErrorPresenter
    {
        public void Show(IRoute route, IEnumerable<IError> errors)
        {
            var view = route[KnownParameters.View] as UserControl;

            var adornerLayer = AdornerLayer.GetAdornerLayer(view);
            adornerLayer.Add(new ErrorsAdorner(view, errors));
        }
    }
}