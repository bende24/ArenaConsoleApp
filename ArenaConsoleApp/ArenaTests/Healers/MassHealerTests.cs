using ArenaConsoleApp.Healers;
using ArenaConsoleApp.Heroes;
using ArenaTests.Heroes;
using Xunit;

namespace ArenaTests.Healers
{
    public class MassHealerTests
    {
        [Fact]
        public void Heals_every_hero()
        {
            var heroes = new IHero[]
            {
                new DummyHero(maxHealth: 100){ CurrentHealth = 20 },
                new DummyHero(maxHealth: 100){ CurrentHealth = 80 },
                new DummyHero(maxHealth: 100){ CurrentHealth = 90 },
            };
            var amountToHeal = 20;
            var expectedHealths = new int[] { 40, 100, 100 };
            var massHealer = new MassHealer(amountToHeal);

            massHealer.Heal(heroes);

            Assert.Equal(expectedHealths, heroes.Select(hero => hero.Health));
        }
    }
}
