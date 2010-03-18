using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;

namespace Chimera.Default.Controllers
{
    public class ReflectionControllerRegistrar : IRouteRegistrar<Type>
    {
        public IDictionary<IRouteSignature, Type> GetSignatures(Assembly assembly)
        {
            var result = new Dictionary<IRouteSignature, Type>();

            var types = assembly.GetTypes();

            var controllerTypes = types.Where(t => t.Name.EndsWith("Controller"));

            foreach (var controllerType in controllerTypes)
            {
                var resource = controllerType.Namespace.Split('.').Last();

                var methods = controllerType.GetActionMethods();

                foreach (var methodInfo in methods)
                {
                    var signature = new LikeRouteSignature(methodInfo.Name, resource);

                    result.Add(signature, controllerType);
                }
            }

            return result;
        }
    }
}