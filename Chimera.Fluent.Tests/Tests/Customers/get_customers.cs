using System.Collections.Generic;
using Chimera.Default.Routing.Extensions;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Interaction.Tests.MockSetup.Customers;
using Chimera.Interaction.Tests.MockSetup.Domain.Customer;
using Chimera.Interaction.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Interaction.Tests.Tests.Customers
{
    [TestClass]
    public class get_customers : TestRoute
    {
        [TestMethod]
        public void should_direct_route_to_customers_controller()
        {
            var likeRoute = new LikeRouteSignature("get", "customers")
                .WithParameter(KnownParameters.Controller);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<CustomersController>(KnownParameters.Controller);
        }

        [TestMethod]
        public void should_get_customers_from_controller()
        {
            var likeRoute = new LikeRouteSignature("get", "customers")
                .WithParameter(KnownParameters.ViewModel);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<IEnumerable<CustomerDto>>(KnownParameters.ViewModel);
        }

        [TestMethod]
        public void should_get_view()
        {
            var likeRoute = new LikeRouteSignature("get", "customers")
                .WithParameter(KnownParameters.ViewModel)
                .WithParameter(KnownParameters.View);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<GetView>(KnownParameters.View);
        }

        [TestMethod]
        public void should_show_get_view_in_window()
        {
            var likeRoute = new LikeRouteSignature("show", "window")
                .WithParameter(KnownParameters.View);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<GetView>(KnownParameters.View);
        }

        public override IRoute GetRoute()
        {
            return "get customers".ToRoute();
        }
    }
}