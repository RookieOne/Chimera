using Chimera.Framework.Routing;

namespace Chimera.Framework.Logging
{
    public interface ILoggingProcessor : IRouteProcessor
    {
        void AddLogger(ILogger logger);
    }
}