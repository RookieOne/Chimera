using System;

namespace Chimera.Framework.Extensions
{
    public static class StringExtensions
    {
        public static string FormatWith(this string s, params object [] args)
        {
            return String.Format(s, args);
        }

        public static bool Matches(this string s1, string s2)
        {
            return s1.ToLower() == s2.ToLower();
        }
    }
}