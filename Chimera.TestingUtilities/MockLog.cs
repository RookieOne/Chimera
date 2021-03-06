﻿using System.Collections.Generic;

namespace Chimera.TestingUtilities
{
    public static class MockLog
    {
        static MockLog()
        {
            _recordings = new Dictionary<string, object>();
        }

        static Dictionary<string, object> _recordings;

        public static void Record(string key, object value)
        {
            if (_recordings.ContainsKey(key))
                _recordings[key] = value;
            else
                _recordings.Add(key, value);
        }

        public static T Read<T>(string key)
        {
            return (_recordings.ContainsKey(key))
                       ? (T) _recordings[key]
                       : default(T);
        }

        public static void Reset()
        {
            _recordings = new Dictionary<string, object>();
        }
    }
}