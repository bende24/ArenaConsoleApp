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
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void Halves_heros_health(int currentHealth, int expectedHealth)
        {
            var hero = new DummyHero(maxHealth: 100) { CurrentHealth = currentHealth };
            var damager = new HeroDamager();

            damager.Damage(hero);

            Assert.Equal(expectedHealth, hero.Health);
        }

        [Theory]
        // Max health, Health before damage, Is dead
        [InlineData(100, 50, false)]
        [InlineData(100, 80, false)]
        [InlineData(100, 100, false)]
        [InlineData(100, 49, true)]
        [InlineData(100, 20, true)]
        [InlineData(100, 1, true)]
        public void Kills_hero_when_health_drops_below_quarter_of_max_health(
            int maxHealth,
            int healthBeforeDamage,
            bool isDead)
        {
            var hero = new DummyHero(maxHealth) { CurrentHealth = healthBeforeDamage };
            var damager = new HeroDamager();

            damager.Damage(hero);

            Assert.Equal(isDead, hero.IsDead());
        }
    }
}
