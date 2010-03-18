using Chimera.Default.Routing.Extensions;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;
using Chimera.Interaction.Tests.MockSetup.Login;
using Chimera.Interaction.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chimera.Framework.Routing.Extensions;
using Chimera.TestingUtilities;

namespace Chimera.Interaction.Tests.Tests.Login
{
    [TestClass]
    public class submit_login_success : TestRoute
    {
        [TestMethod]
        public void should_call_submit_on_controller()
        {
            var likeRoute = new LikeRouteSignature("submit", "login")
                .WithParameter(KnownParameters.Controller);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<LoginController>(KnownParameters.Controller);
        }

        [TestMethod]
        public void should_close_view_and_window()
        {
            var likeRoute = new LikeRouteSignature("close", "window")
                .WithParameter(KnownParameters.View);

            RouteLog.ShouldContainRoute(likeRoute)
                .With<RequestView>("View");
        }

        [TestMethod]
        public void should_inform_listener()
        {
            var listner = IoC.Get<LoginListener>();
            listner.SuccessLoginCalled.ShouldBeTrue();
        }

        public override IRoute GetRoute()
        {            
            var requestViewModel = new RequestViewModel();
            requestViewModel.UserName = "test";
            requestViewModel.Password = "test";

            var route = "submit login".ToRoute();
            route.Parameters.Add("request", requestViewModel);
            route.Parameters.Add(KnownParameters.ParentShowAs, "window");
            route.Parameters.Add(KnownParameters.ParentView, new RequestView());

            return route;
        }
    }
}