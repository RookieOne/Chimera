using System;
using System.Linq;

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
            if (t == typeof(T))
                return true;

            if (t.BaseType == null)
                return false;

            return CanBeCastTo<T>(t.BaseType);
        }
    }
}