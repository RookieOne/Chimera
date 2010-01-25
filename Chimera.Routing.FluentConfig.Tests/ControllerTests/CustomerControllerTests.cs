using Chimera.Framework.Locators;
using Xunit;
using Chimera.Framework.Routing.Default.Tests.TestingHelpers;

namespace Chimera.Framework.Routing.Default.Tests.FluentConfigTests.ControllerTests
{
    public class CustomerControllerTests : ControllerTestSetup
    {
        [Fact]
        public void customer_controller_is_a_singleton()
        {
            RegisterControllers();

            var c1 = Locator.Get<CustomerController>();
            var c2 = Locator.Get<CustomerController>();

            Assert.Same(c1, c2);
        }

        [Fact]
        public void get_customer()
        {
            RegisterControllers();

            var route = new Route("Get", "Customer");
            
            var action = Locator.Get<IRoutingEngine>().Resolve(route);
            action.Invoke(route);

            Locator.Get<CustomerController>().GetCalled.ShouldBeTrue();
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