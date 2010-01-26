using System.Collections.Generic;
using System.Linq;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.RouteSignatures;
using Chimera.TestingUtilities;
using Xunit.Extensions;

namespace Chimera.Routing.Default.Tests.RoutingEngineTests
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

            var routeSignature = new DefaultRouteSignature(route.Action, route.Resource, route.Parameters.Keys.ToArray());
            
            MockLog.Reset();
            
            routingEngine.Register(routeSignature, r => MockLog.Record("Called", true));
            routingEngine.Resolve(route).Invoke(route);

            MockLog.Read<bool>("Called").ShouldBeTrue();
        }
    }
}