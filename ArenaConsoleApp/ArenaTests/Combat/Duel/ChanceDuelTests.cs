using ArenaConsoleApp.Combat.Duel;
using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Rng;
using ArenaTests.Heroes;
using Moq;
using Xunit;

namespace ArenaTests.Combat.Duel
{
    public class ChanceDuelTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Duel_happens_based_on_chances(bool doesDuelHappen)
        {
            var mockChance = new Mock<IChance>();
            mockChance.Setup(m => m.DoesHappen()).Returns(doesDuelHappen);
            var mockDuel = new Mock<IDuel>();
            var duel = new ChanceDuel(mockDuel.Object, mockChance.Object);

            duel.Fight(new DummyHero(), new DummyHero());

            var times = doesDuelHappen ? Times.Once() : Times.Never();
            mockDuel.Verify(m => m.Fight(It.IsAny<IHero>(), It.IsAny<IHero>()), times);
        }
    }
}
