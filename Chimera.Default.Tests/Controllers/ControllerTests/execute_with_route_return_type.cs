using Chimera.Default.Controllers;
using Chimera.Default.Routing;
using Chimera.Default.Routing.Extensions;
using Chimera.Framework.Routing;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Default.Tests.Controllers.ControllerTests
{
    [TestClass]
    public class execute_with_route_return_type
    {
        [TestMethod]
        public void should_return_next_route()
        {
            var c = new TestController();
            var route = "action test".ToRoute();

            var result = c.Execute(route);

            result.Resource.ShouldBe("test");
            result.Action.ShouldBe("success");
        }

        #region Nested type: TestController

        class TestController : Controller
        {
            IRoute Action()
            {
                return new Route("success", "test");
            }
        }

        #endregion
    }
}