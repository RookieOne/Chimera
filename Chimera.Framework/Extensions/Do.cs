using System;

namespace Chimera.Framework.Extensions
{
    public class Do
    {
        public static Action Nothing()
        {
            return () => { };
        }
    }
}