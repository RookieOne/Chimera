using Chimera.Default.Controllers;
using Chimera.Default.Routing;
using Chimera.Framework.Routing;
using Chimera.Default.Errors;

namespace Example.Login
{
    public class LoginController : Controller
    {
        public IRoute Submit(ILoginService service, RequestViewModel request)
        {
            return service.Login(request.UserName, request.Password)
                       ? new Route("success", "login")
                       : new Route("failure", "login").AddError("login failure");
        }
    }
}