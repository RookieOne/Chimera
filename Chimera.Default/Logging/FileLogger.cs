using System;
using System.IO;
using Chimera.Framework.Logging;
using Chimera.Framework.Routing;

namespace Chimera.Default.Logging
{
    public class FileLogger : ILogger
    {
        public FileLogger(string path)
        {
            _writer = new StreamWriter(path);
        }

        readonly StreamWriter _writer;

        public void Log(string message)
        {
            _writer.WriteLine(message);
            _writer.Flush();
        }

        public void Log(IRoute route)
        {
            _writer.WriteLine(route);
            _writer.Flush();
        }
    }
}