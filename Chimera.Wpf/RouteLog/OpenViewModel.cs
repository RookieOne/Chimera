using System.Collections.Generic;
using System.Linq;
using Chimera.Framework.Logging;
using Chimera.Framework.Routing;
using Chimera.Wpf.NotifyPropertyChanged;

namespace Chimera.Wpf.RouteLog
{
    public class OpenViewModel : PropertyChangedBase, ILogger
    {
        public OpenViewModel(ILoggingProcessor processor)
        {
            processor.AddLogger(this);

            _routeLog = new List<IRoute>();
        }

        readonly List<IRoute> _routeLog;
        IEnumerable<IRoute> _routes;

        public IEnumerable<IRoute> Routes
        {
            get { return _routes; }
            set
            {
                _routes = value;
                OnPropertyChanged("Routes");
            }
        }

        public void Log(string message)
        {
            // do nothing
        }

        public void Log(IRoute route)
        {
            _routeLog.Add(route);
            Routes = _routeLog
                .OrderByDescending(r => r.End)
                .ToList();
        }
    }
}