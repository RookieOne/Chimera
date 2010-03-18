namespace Chimera.Framework.Routing
{
    public interface IRoutingEngine
    {
        void AddProcessor(IRouteProcessor processor);
        void Process(IRoute route);
    }
}