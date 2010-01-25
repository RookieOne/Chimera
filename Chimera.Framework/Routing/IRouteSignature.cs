namespace Chimera.Framework.Routing
{
    public interface IRouteSignature
    {
        bool Matches(IRoute route);
    }
}