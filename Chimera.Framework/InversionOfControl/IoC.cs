using System;

namespace Chimera.Framework.InversionOfControl
{
    public static class IoC
    {
        static IChimeraContainer _ioc;

        public static void SetImplementation(IChimeraContainer ioc)
        {
            _ioc = ioc;
        }

        public static T Get<T>()
        {
            return _ioc.Get<T>();
        }

        public static object Get(Type type)
        {
            return _ioc.Get(type);
        }
    }
}