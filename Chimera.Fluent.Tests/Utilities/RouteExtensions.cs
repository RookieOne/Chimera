using Chimera.Framework.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Interaction.Tests.Utilities
{
    public static class RouteExtensions
    {
        public static T With<T>(this IRoute route, string name)
        {
            if (!route.Parameters.ContainsKey(name))
                Assert.Fail("Route does not contain parameter : {0}", name);

            return (T) route.Parameters[name];
        }
    }
}