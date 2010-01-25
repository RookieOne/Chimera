using System;
using System.Collections.Generic;
using System.Linq;

namespace Chimera.Framework.Routing.FluentConfig
{
    public class FromTypesConfig
    {
        public FromTypesConfig(IEnumerable<Type> types)
        {
            _types = types;
        }

        public ActionRegistrationConfig UnderResourceName(Func<Type, string> func)
        {
            var pairings = _types.Select(t => new Tuple<string, Type>(func(t), t));

            return new ActionRegistrationConfig(pairings);
        }

        readonly IEnumerable<Type> _types;
    }
}