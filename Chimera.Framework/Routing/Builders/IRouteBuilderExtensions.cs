using System.Reflection;

namespace Chimera.Framework.Routing.Builders
{
    public static class IRouteBuilderExtensions
    {
        public static IRouteBuilder AddAllParametersFrom(this IRouteBuilder routeBuilder, MethodInfo method)
        {
            foreach (var parameterInfo in method.GetParameters())
            {
                routeBuilder.AddParameter(parameterInfo.Name);
            }

            return routeBuilder;
        }
    }
}