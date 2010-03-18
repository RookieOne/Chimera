using Chimera.Framework.Routing;

namespace Chimera.Framework.Logging
{
    public interface ILogger
    {
        void Log(string message);
        void Log(IRoute route);
    }
}