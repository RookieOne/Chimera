using Chimera.Framework.Routing;

namespace Chimera.Interaction.Tests.Tests
{
    public abstract class TestRoute : SetupDefaultConfig
    {
        protected TestRoute()
        {
            Configure();

            var route = GetRoute();

            _routingEngine.Process(route);
        }

        public abstract IRoute GetRoute();
    }
}