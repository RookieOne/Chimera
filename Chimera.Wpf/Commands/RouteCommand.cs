using System;
using System.Windows.Input;
using Chimera.Default.Routing;
using Chimera.Framework.Routing.Extensions;

namespace Chimera.Wpf.Commands
{
    public class RouteCommand : ICommand
    {
        public RouteCommand(string action, string resource)
        {
            _route = new Route(action, resource);
        }

        readonly Route _route;

        public void Execute(object parameter)
        {
            _route.Send();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public RouteCommand AddParameter(string key, object value)
        {
            _route.AddParameter(key, value);
            return this;
        }
    }
}