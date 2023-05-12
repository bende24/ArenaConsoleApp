using ArenaConsoleApp.Combat;
using ArenaTests.Heroes;
using Xunit;

namespace ArenaTests.Combat
{
    public class HeroDamagerTests
    {
        [Theory]
        // Current health, Expected health
        [InlineData(80, 40)]
        [InlineData(70, 35)]
        [InlineData(85, 42)]
        [InlineData(49, 24)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void Halves_heros_health(int currentHealth, int expectedHealth)
        {
            var hero = new DummyHero(maxHealth: 100) { CurrentHealth = currentHealth };
            var damager = new HeroDamager();

            damager.Damage(hero);

            Assert.Equal(expectedHealth, hero.Health);
        }
    }
}
