using ArenaConsoleApp.ExtensionMethods;
using Xunit;

namespace ArenaTests.ExtensionMethods
{
    public class IEnumerableExtensionMethodsTests
    {
        [Fact]
        public void Decides_if_an_IEnumerable_isNotEmpty()
        {
            var emptyList = new List<int>();
            var nonEmptyList = new List<int> { 1, 2, 3 };

            Assert.False(emptyList.IsNotEmpty());
            Assert.True(nonEmptyList.IsNotEmpty());
        }
    }
}
