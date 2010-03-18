using System.Windows;
using Chimera.Default.Listeners;
using Chimera.Default.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;
using Chimera.Wpf.Commands;

namespace Example.Customers.Menu
{
    public class MenuListener : Listener
    {
        public void OnRegisteredMenu()
        {
            new Route("add", "menu")
                .AddParameter("headers", new[] {"File", "Test"})
                .AddParameter("command", new DelegateCommand(Test))
                .Send();

            new Route("add", "menu")
                .AddParameter("headers", new[] {"View", "Customers"})
                .AddParameter("command", new RouteCommand("get", "customers").AddParameter(KnownParameters.ShowAs, "mdi"))
                .Send();
        }

        void Test()
        {
            MessageBox.Show("Test");
        }
    }
}