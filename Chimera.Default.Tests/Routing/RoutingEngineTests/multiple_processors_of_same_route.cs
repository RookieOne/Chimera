using System.Linq;
using Chimera.Default.Routing;
using Chimera.Default.Routing.Extensions;
using Chimera.Framework.Routing;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Default.Tests.Routing.RoutingEngineTests
{
    [TestClass]
    public class multiple_processors_of_same_route
    {
        IRouteResult _resultA;
        IRouteResult _resultB;

        public void Setup()
        {
            var route = "do step1".ToRoute();

            var step1a = new FuncRouteProcessor
                             {
                                 _CanProcess = r => r.Resource == "step1",
                                 _Process = r => _resultA = new EndRouteResult(r)
                             };
            var step1b = new FuncRouteProcessor
                             {
                                 _CanProcess = r => r.Resource == "step1",
                                 _Process = r => _resultB = new EndRouteResult(r)
                             };

            var engine = new RoutingEngine();
            engine.AddProcessor(step1a);
            engine.AddProcessor(step1b);

            engine.Process(route);
        }

        [TestMethod]
        public void should_process_step1a()
        {
            Setup();

            _resultA.ShouldNotBeNull();
        }

        [TestMethod]
        public void should_process_step1b()
        {
            Setup();

            _resultB.ShouldNotBeNull();
        }

        [TestMethod]
        public void should_go_down_different_paths()
        {
            Setup();

            _resultA.History.Count().ShouldBe(1);
            _resultB.History.Count().ShouldBe(1);
        }
    }
}