using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Chimera.Default.Controllers;
using Chimera.Default.Routing;
using Chimera.Framework.Routing;

namespace Example.Menu
{
    public class MenuController : Controller
    {
        static IMenu _menu;

        public IRoute Register(IMenu menu)
        {
            _menu = menu;
            return new Route("registered", "menu");
        }

        public void Add(IEnumerable<string> headers, ICommand command)
        {
            _menu.Add(command, headers.ToArray());
        }

        public void Remove(IEnumerable<string> headers)
        {
            _menu.Remove(headers.ToArray());
        }
    }
}