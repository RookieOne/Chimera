using System.Collections.Generic;

namespace Chimera.Framework.Extensions
{
    public static class DictionaryExtensions
    {
        public static void SafeRemove<K, V>(this IDictionary<K, V> dictionary, K key)
        {
            if (dictionary.ContainsKey(key))
                dictionary.Remove(key);
        }
    }
}