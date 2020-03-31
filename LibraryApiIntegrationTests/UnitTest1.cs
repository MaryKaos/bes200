using System;
using Xunit;

namespace LibraryApiIntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var a = 10;
            var b = 11;

            Assert.Equal(21, a + b);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(10, 5, 15)]
        [InlineData(2, 498, 500)]
        public void CanAddTwoNumbers(int a, int b, int expected)
        {
            var sum = a + b;
            Assert.Equal(expected, sum);
        }
    }
}
