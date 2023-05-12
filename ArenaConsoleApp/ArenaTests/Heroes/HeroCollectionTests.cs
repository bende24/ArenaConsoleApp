using ArenaConsoleApp.Heroes;
using Xunit;

namespace ArenaTests.Heroes
{
    public class HeroCollectionTests
    {
        [Fact]
        public void Cant_add_dead_heroes_to_collection()
        {
            var hero = new DummyHero() { CurrentHealth = 0 };
            Assert.True(hero.IsDead());
            var heroes = new HeroCollection
            {
                hero
            };

            Assert.Empty(heroes);
        }

        [Fact]
        public void Can_add_alive_heroes_to_collection()
        {
            var hero = new DummyHero();
            Assert.True(hero.IsAlive());
            var heroes = new HeroCollection
            {
                hero
            };

            Assert.NotEmpty(heroes);
        }
    }
}
