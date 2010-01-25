namespace Chimera.Framework.Routing.Default
{
    public class RouteBuilder : IRouteBuilder
    {
        Route _route;

        public IRouteBuilder StartRoute(string action, string resource)
        {
            _route = new Route(action, resource);
            return this;
        }

        public IRouteBuilder AddParameter(string name)
        {
            _route.AddParameter(name, null);
            return this;
        }

        public IRoute Build()
        {
            return _route;
        }
    }
}