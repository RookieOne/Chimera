using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Chimera.Default.Routing.RouteSignatures;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;

namespace Chimera.Default.Listeners
{
    public class ReflectionListenerRegistrar : IRouteRegistrar<Type>
    {
        public IDictionary<IRouteSignature, Type> GetSignatures(Assembly assembly)
        {
            var result = new Dictionary<IRouteSignature, Type>();

            var types = assembly.GetTypes();

            var listenerTypes = types.Where(t => t.Name.EndsWith("Listener"));

            foreach (var listenerType in listenerTypes)
            {
                var methods = listenerType.GetActionMethods()
                    .Where(m => m.Name.StartsWith("On"));

                foreach (var methodInfo in methods)
                {
                    var methodName = methodInfo.Name.Remove(0, 2);

                    var actionAndResource = GetActionAndResource(methodName);

                    var signature = new LikeRouteSignature(actionAndResource.Item1, actionAndResource.Item2);

                    result.Add(signature, listenerType);
                }
            }

            return result;
        }

        Tuple<string, string> GetActionAndResource(string methodName)
        {
            Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
            var asWords = r.Replace(methodName, " ${x}").Split(' ');

            return new Tuple<string, string>(asWords[0], asWords[1]);
        }
    }
}