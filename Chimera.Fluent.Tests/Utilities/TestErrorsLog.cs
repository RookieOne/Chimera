using System.Collections.Generic;
using System.Linq;
using Chimera.Framework.Errors;
using Chimera.Framework.Routing;

namespace Chimera.Interaction.Tests.Utilities
{
    public class TestErrorsLog : IErrorPresenter
    {
        public TestErrorsLog()
        {
            Errors = new List<IError>();
        }

        public IEnumerable<IError> Errors { get; set; }

        public void Show(IRoute route, IEnumerable<IError> errors)
        {
            Errors = Errors.Union(errors);
        }
    }
}