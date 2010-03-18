using System;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;

namespace Chimera.Default.Errors
{
    public class NoErrorsFoundToShowException : Exception
    {
        public NoErrorsFoundToShowException(IRoute route)
            : base(GetMessage(route))
        {
        }

        static string GetMessage(IRoute route)
        {
            return "No errors found to show in {0}".FormatWith(route);
        }
    }
}