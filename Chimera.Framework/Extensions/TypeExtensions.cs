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
    }
}