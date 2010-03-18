using Chimera.Framework.Extensions;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Framework.Tests.Extensions.TypeExtensionTests
{
    [TestClass]
    public class CanBeCastToTests
    {
        [TestMethod]
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