using Chimera.Default.Routing.Extensions;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.Routing;
using Chimera.Interaction.Tests.MockSetup.Login;
using Chimera.Interaction.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Interaction.Tests.Tests.Login
{
    [TestClass]
    public class request_login : TestRoute
    {
        [TestMethod]
        public void should_get_request_view_model()
        {
            var likeRoute = new LikeRouteSignature("request", "login")
                .WithParameter("ViewModel");

            RouteLog.ShouldContainRoute(likeRoute)
                .With<RequestViewModel>("ViewModel");
        }

        [TestMethod]
        public void should_get_request_view()
        {
            var likeRoute = new LikeRouteSignature("request", "login")
                .WithParameter("ViewModel")
                .WithParameter("View");

            RouteLog.ShouldContainRoute(likeRoute)
                .With<RequestView>("View");
        }

        [TestMethod]
        public void should_show_request_view_in_window()
        {
            var likeRoute = new LikeRouteSignature("show", "window")                
                .WithParameter("View");

            RouteLog.ShouldContainRoute(likeRoute)
                .With<RequestView>("View");
        }

        public override IRoute GetRoute()
        {
            return "request login".ToRoute();
        }
    }
}