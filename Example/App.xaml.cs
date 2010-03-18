using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Chimera.Default.Routing.Extensions;
using Chimera.Fluent;
using Chimera.Framework.Extensions;
using Chimera.StructureMap;
using Chimera.Wpf.Presenters;
using Chimera.Wpf.Views;
using Example.Customers.Customers;
using Example.Customers.Domain.Customer;
using Example.Login;

namespace Example
{
    /// <summary>
    ///   Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new StructureMapContainer();

            var config = Configuration.Default(container);

            GetAssemblies().ForEach(a => config.Register(a));

            config.DefaultShowAs("window").SetViewBinder(new WpfViewBinder());
            config.SetErrorPresenter<ErrorPresenter>();
            config.AddPresenter<WindowPresenter>();
            config.AddPresenter<MdiPresenter>();

            "open routelog".Send();
            "request login".Send();
        }

        IEnumerable<Assembly> GetAssemblies()
        {
            return new[]
                       {
                           Assembly.GetAssembly(typeof (App)),
                           Assembly.GetAssembly(typeof (WpfViewBinder)),
                           Assembly.GetAssembly(typeof (LoginService)),
                           Assembly.GetAssembly(typeof (ICustomerRepository)),
                       };
        }
    }
}