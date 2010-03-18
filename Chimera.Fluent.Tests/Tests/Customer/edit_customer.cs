using Chimera.Default.Routing;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Interaction.Tests.MockSetup.Customer;
using Chimera.Interaction.Tests.MockSetup.Domain.Customer;
using Chimera.Interaction.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Interaction.Tests.Tests.Customer
{
    [TestClass]
    public class edit_customer : TestRoute
    {
        [TestMethod]
        public void should_direct_route_to_customer_controller()
        {
            var likeRoute = new LikeRouteSignature("edit", "customer")
                .WithParameter(KnownParameters.Controller);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<CustomerController>(KnownParameters.Controller);
        }

        [TestMethod]
        public void should_get_customers_from_controller()
        {
            var likeRoute = new LikeRouteSignature("edit", "customer")
                .WithParameter(KnownParameters.ViewModel);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<CustomerDto>(KnownParameters.ViewModel);
        }

        [TestMethod]
        public void should_get_view()
        {
            var likeRoute = new LikeRouteSignature("edit", "customer")
                .WithParameter(KnownParameters.ViewModel)
                .WithParameter(KnownParameters.View);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<EditView>(KnownParameters.View);
        }

        [TestMethod]
        public void should_show_get_view_in_mdi()
        {
            var likeRoute = new LikeRouteSignature("show", "mdi")
                .WithParameter(KnownParameters.View);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<EditView>(KnownParameters.View);
        }

        public override IRoute GetRoute()
        {
            return new Route("edit", "customer")
                .AddParameter("id", 1)
                .AddParameter(KnownParameters.ShowAs, "mdi");
        }
    }
}