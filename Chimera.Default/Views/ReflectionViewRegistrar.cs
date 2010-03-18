using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.Routing;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Views
{
    public class ReflectionViewRegistrar : IRouteRegistrar<Type>
    {
        public IDictionary<IRouteSignature, Type> GetSignatures(Assembly assembly)
        {
            var result = new Dictionary<IRouteSignature, Type>();

            var types = assembly.GetTypes();

            var viewTypes = types.Where(t => t.Name.EndsWith("View"));

            foreach (var viewType in viewTypes)
            {
                var action = viewType.Name.Replace("View", "");
                var resource = viewType.Namespace.Split('.').Last();

                var signature = new LikeRouteSignature(action, resource)
                    .WithParameter(KnownParameters.ViewModel)
                    .WithoutParameter(KnownParameters.View);

                result.Add(signature, viewType);
            }

            return result;
        }
    }
}