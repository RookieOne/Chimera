using System;

namespace Chimera.Framework.Locators
{
    public static class Locator
    {
        static ILocator _implementation;

        public static void SetImplementation(ILocator locator)
        {
            _implementation = locator;
        }

        public static T Get<T>()
        {
            return _implementation.Get<T>();
        }

        public static object Get(Type type)
        {
            return _implementation.Get(type);
        }
    }
}