using Xunit;

namespace Chimera.TestingUtilities
{
    public static class AssertExtensions
    {
        public static void ShouldBeTrue(this bool b)
        {
            Assert.True(b);
        }

        public static void ShouldBe(this int actual, int expected)
        {
            Assert.Equal(expected, actual);
        }

        public static void ShouldBeTheSameAs(this object actual, object expected)
        {
            Assert.Same(expected, expected);
        }
    }
}