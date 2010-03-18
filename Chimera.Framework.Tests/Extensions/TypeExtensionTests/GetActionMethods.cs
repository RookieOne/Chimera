using System.Linq;
using Chimera.Framework.Extensions;
using Chimera.TestingUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.Framework.Tests.Extensions.TypeExtensionTests
{
    [TestClass]
    public class GetActionMethods
    {
        [TestMethod]
        public void should_find_1_action_method()
        {
            var methods = typeof (MockController).GetActionMethods();

            methods.Count().ShouldBe(1);
        }

        #region Nested type: MockController

        class MockController
        {
            void Action()
            {
            }
        }

        #endregion
    }
}