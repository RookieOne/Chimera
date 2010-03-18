using System;
using System.Windows;

namespace Chimera.Wpf.Extensions
{
    public static class DurationExtensions
    {
        public static Duration Seconds(this int seconds)
        {
            return new Duration(new TimeSpan(0, 0, seconds));
        }

        public static Duration MilliSeconds(this int milliseconds)
        {
            return new Duration(new TimeSpan(0, 0, 0, 0, milliseconds));
        }
    }
}