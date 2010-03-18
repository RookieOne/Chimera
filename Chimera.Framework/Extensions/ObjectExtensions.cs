namespace Chimera.Framework.Extensions
{
    public static class ObjectExtensions
    {
        public static T As<T>(this object o)
        {
            return (T) o;
        }
    }
}