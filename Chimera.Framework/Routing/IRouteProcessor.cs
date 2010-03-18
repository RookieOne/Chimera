namespace Chimera.Framework.Routing
{
    public interface IRouteProcessor
    {
        bool CanProcess(IRoute route);
        IRouteResult Process(IRoute route);
    }
}