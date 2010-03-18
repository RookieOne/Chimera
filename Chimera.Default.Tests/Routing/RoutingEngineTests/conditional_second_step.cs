using System.Linq;
using Chimera.Default.Routing;
using Chimera.Default.Routing.Extensions;
using Chimera.Framework.Routing;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Default.Tests.Routing.RoutingEngineTests
{
    [TestClass]
    public class conditional_second_step
    {
        RoutingEngine _engine;
        IRouteResult _result;

        public void Arrange()
        {
            var step1 = new FuncRouteProcessor
                            {
                                _CanProcess = r => r.Resource == "step1",
                                _Process = r => _result = new EndRouteResult(r)
                            };
            var step2 = new FuncRouteProcessor
                            {
                                _CanProcess = r => r.Resource == "step2",
                                _Process = r => _result = new EndRouteResult(r)
                            };

            _engine = new RoutingEngine();
            _engine.AddProcessor(step1);
            _engine.AddProcessor(step2);
        }

        [TestMethod]
        public void should_do_step_1()
        {
            Arrange();

            _engine.Process("do step1".ToRoute());

            _result.ShouldNotBeNull();
            _result.History.Count().ShouldBe(1);
        }

        [TestMethod]
        public void should_do_step_2()
        {
            Arrange();

            _engine.Process("do step2".ToRoute());

            _result.ShouldNotBeNull();
            _result.History.Count().ShouldBe(1);
        }
    }
}