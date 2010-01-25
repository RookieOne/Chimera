using System;

namespace Chimera.Framework.InversionOfControl.Conventions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : Attribute
    {
        public SingletonAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }
    }
}