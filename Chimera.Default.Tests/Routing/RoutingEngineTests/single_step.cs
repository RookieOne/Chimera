using Chimera.Default.Routing;
using Chimera.Default.Routing.Extensions;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Default.Tests.Routing.RoutingEngineTests
{
    [TestClass]
    public class single_step
    {
        [TestMethod]
        public void should_process_valid_route()
        {
            RouteResult result = null;

            var route = "valid request".ToRoute();

            var p = new FuncRouteProcessor();
            p._CanProcess = r => r.Action == "valid";
            p._Process = r => result = new EndRouteResult(route);

            var c = new RoutingEngine();
            c.AddProcessor(p);

            c.Process(route);

            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void should_not_process_invalid_route()
        {
            RouteResult result = null;

            var route = "invalid request".ToRoute();

            var p = new FuncRouteProcessor();
            p._CanProcess = r => r.Action == "valid";
            p._Process = r => result = new EndRouteResult(route);

            var c = new RoutingEngine();
            c.AddProcessor(p);

            c.Process(route);

            result.ShouldBeNull();
        }
    }
}