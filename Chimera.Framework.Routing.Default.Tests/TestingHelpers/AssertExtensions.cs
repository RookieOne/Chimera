﻿using Xunit;

namespace Chimera.Framework.Routing.Default.Tests.TestingHelpers
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
    }
}