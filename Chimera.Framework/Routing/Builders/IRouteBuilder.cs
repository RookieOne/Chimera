namespace Chimera.Framework.Routing.Builders
{
    public interface IRouteBuilder
    {
        IRouteBuilder StartRoute(string action, string resource);
        IRouteBuilder AddParameter(string name);
        IRoute Build();
    }
}