using ArenaConsoleApp.ExtensionMethods;
using Xunit;

namespace ArenaTests.ExtensionMethods
{
    public class IntExtensionMethodTests
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(10, false)]
        [InlineData(0, false)]
        public void Determines_if_number_is_odd(int number, bool isOdd)
        {
            Assert.Equal(isOdd, number.IsOdd());
        }
    }
}
