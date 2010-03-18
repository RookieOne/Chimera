using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chimera.Framework.Extensions
{
    public static class TypeExtensions
    {
        public static bool HasAttribute<T>(this Type t)
        {
            return t.GetCustomAttributes(typeof (T), true).Count() > 0;
        }

        public static T GetAttribute<T>(this Type t)
        {
            return (T) t.GetCustomAttributes(typeof (T), true).First();
        }

        public static bool CanBeCastTo<T>(this Type t)
        {
            if (t == typeof (T))
                return true;

            var foundInterface = t.GetInterfaces().FirstOrDefault(i => i == typeof (T));
            if (foundInterface != null)
                return true;

            if (t.BaseType == null)
                return false;

            return CanBeCastTo<T>(t.BaseType);
        }

        public static string[] GetParameterNames(this MethodInfo method)
        {
            return method.GetParameters().Select(p => p.Name).ToArray();
        }

        public static IEnumerable<MethodInfo> GetActionMethods(this Type t)
        {
            return t.GetMethods(BindingFlags.Instance
                                | BindingFlags.NonPublic
                                | BindingFlags.Public
                                | BindingFlags.DeclaredOnly);
        }
    }
}