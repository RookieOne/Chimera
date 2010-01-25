namespace Chimera.Framework.Routing
{
    public interface IRouteBuilder
    {
        IRouteBuilder StartRoute(string action, string resource);
        IRouteBuilder AddParameter(string name);
        IRoute Build();
    }
}