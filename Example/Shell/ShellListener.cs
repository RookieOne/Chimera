using Chimera.Default.Listeners;
using Chimera.Default.Routing;
using Chimera.Framework.Routing;

namespace Example.Shell
{
    public class ShellListener : Listener
    {
        public IRoute OnSuccessLogin()
        {
            return new Route("open", "shell");
        }
    }
}