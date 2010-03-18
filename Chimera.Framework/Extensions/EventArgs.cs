using System;

namespace Chimera.Framework.Extensions
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}