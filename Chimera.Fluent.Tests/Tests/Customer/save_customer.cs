using Chimera.Default.Routing;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Interaction.Tests.MockSetup.Customer;
using Chimera.Interaction.Tests.MockSetup.Domain.Customer;
using Chimera.Interaction.Tests.Utilities;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Interaction.Tests.Tests.Customer
{
    [TestClass]
    public class save_customer : TestRoute
    {
        CustomerDto _customerToSave;

        [TestMethod]
        public void should_direct_route_to_customer_controller()
        {
            var likeRoute = new LikeRouteSignature("save", "customer")
                .WithParameter(KnownParameters.Controller);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<CustomerController>(KnownParameters.Controller);
        }

        [TestMethod]
        public void should_save_customer_in_repository()
        {
            CustomerRepository.CustomerSaved.ShouldBe(_customerToSave);
        }

        [TestMethod]
        public void should_save_success()
        {
            var likeRoute = new LikeRouteSignature("success", "customer")
                .WithParameter("customer");

            RouteLog.ShouldContainRoute(likeRoute)
                .With<CustomerDto>("customer");
        }

        [TestMethod]
        public void should_close_view_and_mdi()
        {
            var likeRoute = new LikeRouteSignature("close", "mdi")
                .WithParameter(KnownParameters.View);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<EditView>("View");
        }

        public override IRoute GetRoute()
        {
            _customerToSave = new CustomerDto
                                  {
                                      Id = 10,
                                      Name = "Aaron"
                                  };
            return new Route("save", "customer")
                .AddParameter("customer", _customerToSave)
                .AddParameter(KnownParameters.ParentShowAs, "mdi")
                .AddParameter(KnownParameters.ParentView, new EditView());
        }
    }
}