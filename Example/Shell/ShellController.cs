using Chimera.Default.Controllers;
using Chimera.Default.Routing;
using Chimera.Framework.Routing;

namespace Example.Shell
{
    public class ShellController : Controller
    {
        public IRoute Open()
        {
            return new Route("display", "shell");
        }
    }
}