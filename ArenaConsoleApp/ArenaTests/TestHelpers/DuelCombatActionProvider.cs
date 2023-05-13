using ArenaConsoleApp.Combat;
using ArenaConsoleApp.CompositionRoots;
using ArenaConsoleApp.Rng;
using Moq;

namespace ArenaTests.TestHelpers
{
    internal class DuelCombatActionProvider
    {
        public static DuelCombatAction GetWithRealDuelRules(int randomGeneratedNumber = 1)
        {
            var mockRandom = new Mock<IRandom>();
            mockRandom.Setup(m => m.GenerateNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(randomGeneratedNumber);
            var duelProvider = DuelProviderFactory.CreateDuelGrid(mockRandom.Object);
            return new DuelCombatAction(duelProvider);
        }
    }
}
