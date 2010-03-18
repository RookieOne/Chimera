using Chimera.Default.Controllers;
using Chimera.Default.Routing.Extensions;
using Chimera.Default.Tests.Utilities;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Default.Tests.Controllers.ControllerTests
{
    [TestClass]
    public class execute_with_dependencies
    {
        TestController _controller;
        IRouteResult _result;

        public void Setup()
        {
            var container = new MockContainer();
            container.Register(typeof (ITestService), typeof (TestService));
            IoC.SetImplementation(container);

            _controller = new TestController();

            var route = "action test".ToRoute();
            _result = _controller.Execute(route);
        }

        [TestMethod]
        public void should_return_next_route()
        {
            Setup();

            _result.Resource.ShouldBe("test");
            _result.Action.ShouldBe("success");
        }

        [TestMethod]
        public void should_resolve_test_service()
        {
            Setup();

            _controller.Service.ShouldBeOfType<TestService>();
        }

        #region Nested type: ITestService

        interface ITestService
        {
        }

        #endregion

        #region Nested type: TestController

        class TestController : Controller
        {
            public ITestService Service { get; set; }

            string Action(ITestService service)
            {
                Service = service;
                return "success test";
            }
        }

        #endregion

        #region Nested type: TestService

        class TestService : ITestService
        {
        }

        #endregion
    }
}