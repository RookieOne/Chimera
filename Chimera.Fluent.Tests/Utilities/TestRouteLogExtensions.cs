using System.Linq;
using Chimera.Framework.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Interaction.Tests.Utilities
{
    public static class TestRouteLogExtensions
    {
        public static IRoute ShouldContainRoute(this TestRouteLog log, IRouteSignature signature)
        {
            var match = log.Log.FirstOrDefault(signature.Matches);

            if (match == null)
                Assert.Fail("No route like '{0}' found in log", signature);

            return match;
        }
    }
}