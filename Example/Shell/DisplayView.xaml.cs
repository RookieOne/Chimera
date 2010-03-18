using System.Windows.Controls;
using Chimera.Default.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;
using Example.Menu;

namespace Example.Shell
{
    /// <summary>
    ///   Interaction logic for DisplayView.xaml
    /// </summary>
    public partial class DisplayView : UserControl
    {
        public DisplayView()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
                               {
                                   new Route("register", "menu")
                                       .AddParameter("menu", new WpfMenu(menu))
                                       .Send();

                                   new Route("register", "mdi")
                                   .AddParameter(KnownParameters.PresenterHost, mdiContainer)
                                   .Send();
                               };
        }
    }
}