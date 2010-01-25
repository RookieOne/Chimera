﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chimera.Framework.Routing
{
    public static class IRouteExtensions
    {
        public static bool IsSameRouteAs(this IRoute route, IRoute other)
        {
            if (route.Resource != other.Resource)
                return false;

            if (route.Action != other.Action)
                return false;

            if (route.Parameters.Keys.Except(other.Parameters.Keys).Count() != 0)
                return false;

            return true;
        }

        public static object[] GetParametersFor(this IRoute route, MethodInfo method)
        {
            var parameterValues = new List<object>();
            foreach (var parameter in method.GetParameters())
            {
                parameterValues.Add(route.Parameters[parameter.Name]);
            }

            return parameterValues.ToArray();
        }
    }
}