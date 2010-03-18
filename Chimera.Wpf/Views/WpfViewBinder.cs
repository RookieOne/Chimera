using System.Windows;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Framework.Views;
using Chimera.Wpf.AttachedProperties;

namespace Chimera.Wpf.Views
{
    public class WpfViewBinder : IViewBinder
    {
        public void Bind(IRoute route)
        {
            var view = route[KnownParameters.View];
            var element = view as FrameworkElement;
            if (element == null)
                return;

            var model = route[KnownParameters.ViewModel];

            element.DataContext = model;
            ViewProperties.SetView(element, route[KnownParameters.View]);
            ViewProperties.SetShowAs(element, route[KnownParameters.ShowAs].ToString());
        }
    }
}