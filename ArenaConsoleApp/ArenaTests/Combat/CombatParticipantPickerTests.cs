using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Rng;
using ArenaTests.Heroes;
using Moq;
using Xunit;

namespace ArenaTests.Combat
{
    public class CombatParticipantPickerTests
    {
        [Theory] // Test list has 4 items
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 3)]
        public void Picks_an_attacker_and_a_defender(params int[] indexes)
        {
            var heroes = new List<IHero>()
            {
                new DummyHero(),
                new DummyHero(),
                new DummyHero(),
                new DummyHero(),
            };
            var mockRandoms = new Mock<IRandoms>();
            mockRandoms.Setup(m => m.GenerateNumbers(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>())).Returns(indexes);
            var picker = GetPicker(mockRandoms.Object);

            var participants = picker.Pick(heroes);

            Assert.Equal(heroes[indexes[0]], participants.Attacker);
            Assert.Equal(heroes[indexes[1]], participants.Defender);
        }

        [Fact]
        public void Throws_Exception_when_there_are_less_than_2_heroes()
        {
            var emptyList = new List<IHero>();
            var singleElementList = new List<IHero>() { new DummyHero() };
            var picker = GetPicker();

            Assert.Throws<Exception>(() => picker.Pick(emptyList));
            Assert.Throws<Exception>(() => picker.Pick(singleElementList));
        }

        private ICombatParticipantsPicker GetPicker(IRandoms? randoms = null)
        {
            randoms ??= Mock.Of<IRandoms>();
            return new CombatParticipantsPicker(randoms);
        }
    }
}
