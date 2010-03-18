using System.Collections.Generic;
using System.Linq;
using Chimera.Default.Routing;
using Chimera.Framework.Routing;

namespace Chimera.Interaction.Tests.Utilities
{
    public class TestRouteLog : IRouteProcessor
    {
        public TestRouteLog()
        {
            _log = new List<IRoute>();
        }

        readonly List<IRoute> _log;

        public IEnumerable<IRoute> Log
        {
            get { return _log; }
        }

        public bool CanProcess(IRoute route)
        {
            return true;
        }

        public IRouteResult Process(IRoute route)
        {
            _log.Add(route);
            return new EndRouteResult(route);
        }

        public IEnumerable<IRoute> GetRoutesLike(IRouteSignature signature)
        {
            return _log.Where(r => signature.Matches(r));
        }
    }
}