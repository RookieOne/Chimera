using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Routing.Default;
using Chimera.TestingUtilities;
using Xunit;

namespace Chimera.Routing.FluentConfig.Tests.ControllerTests
{
    public class CustomerControllerTests : ControllerTestSetup
    {
        [Fact]
        public void customer_controller_is_a_singleton()
        {
            RegisterControllers();

            var c1 = IoC.Get<CustomerController>();
            var c2 = IoC.Get<CustomerController>();

            Assert.Same(c1, c2);
        }

        [Fact]
        public void get_customer()
        {
            RegisterControllers();

            var route = new Route("Get", "Customer");

            var action = IoC.Get<IRoutingEngine>().Resolve(route);
            action.Invoke(route);

            IoC.Get<CustomerController>().GetCalled.ShouldBeTrue();
        }
    }

    public class CustomerController
    {
        public bool GetCalled;

        public void Get()
        {
            GetCalled = true;
        }
    }
}