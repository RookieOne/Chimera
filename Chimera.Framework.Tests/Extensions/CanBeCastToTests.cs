using Chimera.Framework.Extensions;
using Chimera.TestingUtilities;
using Xunit;

namespace Chimera.Framework.Tests.Extensions
{
    public class CanBeCastToTests
    {
        [Fact]
        public void should_return_true_if_implements_interface()
        {
            typeof (Foo).CanBeCastTo<IFoo>().ShouldBeTrue();
        }

        class Foo : IFoo
        {
        }

        interface IFoo
        {
        }
    }
}