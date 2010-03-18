using System.Collections.Generic;
using Chimera.Framework.Logging;
using Chimera.Framework.Routing;

namespace Chimera.Default.Logging
{
    public class InMemoryLogger : ILogger
    {
        public InMemoryLogger()
        {
            Messages = new List<string>();
            Routes = new List<IRoute>();
        }

        public List<string> Messages { get; set; }
        public List<IRoute> Routes { get; set; }

        public void Log(string message)
        {
            Messages.Add(message);
        }

        public void Log(IRoute route)
        {
            Routes.Add(route);
        }
    }
}