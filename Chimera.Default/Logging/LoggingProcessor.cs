using System.Collections.Generic;
using Chimera.Default.Routing;
using Chimera.Framework.Logging;
using Chimera.Framework.Routing;

namespace Chimera.Default.Logging
{
    public class LoggingProcessor : ILoggingProcessor
    {
        public LoggingProcessor()
        {
            _loggers = new List<ILogger>();
        }

        readonly List<ILogger> _loggers;

        public bool CanProcess(IRoute route)
        {
            return true;
        }

        public IRouteResult Process(IRoute route)
        {
            _loggers.ForEach(l => l.Log(route));

            return new EndRouteResult(route);
        }

        public void AddLogger(ILogger logger)
        {
            _loggers.Add(logger);
        }
    }
}