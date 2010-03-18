using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chimera.TestingUtilities
{
    public static class AssertExtensions
    {
        public static void ShouldNotBeNull<T>(this T x)
        {
            Assert.IsNotNull(x);
        }

        public static void ShouldBeNull<T>(this T x)
        {
            Assert.IsNull(x);
        }

        public static void ShouldBeTrue(this bool b)
        {
            Assert.IsTrue(b);
        }

        public static void ShouldBeFalse(this bool b)
        {
            Assert.IsFalse(b);
        }

        public static void ShouldBe<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void ShouldNotBe<T>(this T actual, T expected)
        {
            Assert.AreNotEqual(expected, actual);
        }

        public static void ShouldBeTheSameAs(this object actual, object expected)
        {
            Assert.AreSame(expected, expected);
        }

        public static void ShouldBeOfType<T>(this object o)
        {
            Assert.IsInstanceOfType(o, typeof(T));
        }
    }
}