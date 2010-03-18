using Chimera.Default.Controllers;
using Chimera.Default.Errors;
using Chimera.Default.Routing;
using Chimera.Framework.Errors;
using Chimera.Framework.Routing;

namespace Chimera.Interaction.Tests.MockSetup.Login
{
    public class LoginController : Controller
    {
        public IRoute Submit(ILoginService service, RequestViewModel request)
        {
            var success = service.Login(request.UserName, request.Password);

            if (success)
                return new Route("success", "login");

            return new Route("failure", "login")
                .AddError("login failed");
        }
    }
}