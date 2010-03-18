using Chimera.Default.Routing;
using Chimera.Default.Routing.Extensions;
using Chimera.Framework.Routing;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Chimera.Default.Tests.Routing.RoutingEngineTests
{
    [TestClass]
    public class two_steps
    {
        IRouteResult _result;
        IRoute _route1;
        IRoute _route2;

        public void Setup()
        {
            _route1 = "do step1".ToRoute();
            _route2 = "do step2".ToRoute();

            var step1 = new FuncRouteProcessor
                            {
                                _CanProcess = r => r.Resource == "step1",
                                _Process = r => new RouteResult(r).Next(_route2)
                            };


            var step2 = new FuncRouteProcessor
                            {
                                _CanProcess = r => r.Resource == "step2",
                                _Process = r => _result = new EndRouteResult(r)
                            };
            
            var engine = new RoutingEngine();
            engine.AddProcessor(step1);
            engine.AddProcessor(step2);
            engine.Process(_route1);
        }

        [TestMethod]
        public void should_process_first_step()
        {
            Setup();

            _result.History.Contains(_route1).ShouldBeTrue();   
        }

        [TestMethod]
        public void should_process_second_step()
        {
            Setup();

            _result.History.Contains(_route2).ShouldBeTrue();
        }

        [TestMethod]
        public void should_have_2_routes_in_history()
        {
            Setup();

            _result.History.Count().ShouldBe(2);
        }
    }
}