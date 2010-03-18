using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.Routing;

namespace Chimera.Default.ViewModels
{
    public class ReflectionViewModelRegistrar : IRouteRegistrar<Type>
    {
        public IDictionary<IRouteSignature, Type> GetSignatures(Assembly assembly)
        {
            var result = new Dictionary<IRouteSignature, Type>();

            var types = assembly.GetTypes();

            var viewModelTypes = types.Where(t => t.Name.EndsWith("ViewModel"));

            foreach (var viewModelType in viewModelTypes)
            {
                var action = viewModelType.Name.Replace("ViewModel", "");
                var resource = viewModelType.Namespace.Split('.').Last();

                var signature = new LikeRouteSignature(action, resource);
                
                result.Add(signature, viewModelType);
            }

            return result;
        }
    }
}