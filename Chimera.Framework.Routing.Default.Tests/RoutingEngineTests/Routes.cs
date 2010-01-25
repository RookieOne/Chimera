using System.Collections.Generic;
using Chimera.Framework.Routing.Default.Tests.TestingHelpers;
using Xunit.Extensions;

namespace Chimera.Framework.Routing.Default.Tests.RoutingEngineTests
{
    public class Routes
    {
        public static IEnumerable<object[]> TestRoutes
        {
            get
            {
                yield return new object[] {new Route("Get", "Customers")};
                yield return new object[] {new Route("GetList", "Customer")};
                yield return new object[] {new Route("Get", "Customer").AddParameter("Id", 100)};
                yield return
                    new object[]
                        {new Route("Get", "Customer").AddParameter("Status", "gold").AddParameter("Name", "JB")};
            }
        }

        [Theory]
        [PropertyData("TestRoutes")]
        public void TestRoute(IRoute route)
        {
            var routingEngine = new RoutingEngine();
            var mappedAction = new ActionRecorder();

            routingEngine.Register(route, r => mappedAction.RecordExecution());
            routingEngine.Resolve(route).Invoke(route);

            mappedAction.WasExecuted().ShouldBeTrue();
        }
    }
}