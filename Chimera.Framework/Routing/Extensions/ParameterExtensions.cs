using Chimera.Framework.Extensions;
using Enumerable = System.Linq.Enumerable;

namespace Chimera.Framework.Routing.Extensions
{
    public static class ParameterExtensions
    {
        public static IRoute AddParameter(this IRoute r, string key, object value)
        {
            if (!r.Parameters.ContainsKey(key))
                r.Parameters.Add(key, null);

            r.Parameters[key] = value;
            return r;
        }

        public static IRoute CopyParameterFrom(this IRoute destination, IRoute source, string parameter)
        {
            if (source.Contains(parameter))
            {
                destination.AddParameter(parameter, source[parameter]);
            }

            return destination;
        }

        public static bool Contains(this IRoute r, string key)
        {
            return r.Parameters.ContainsKey(key);
        }

        public static bool DoesNotContain(this IRoute r, string key)
        {
            return !r.Parameters.ContainsKey(key);
        }

        public static bool HasSingleParameterOfType<T>(this IRoute route)
        {
            if (route.Parameters.Count > 1)
                return false;

            return Enumerable.First(route.Parameters).GetType().CanBeCastTo<T>();
        }
    }
}