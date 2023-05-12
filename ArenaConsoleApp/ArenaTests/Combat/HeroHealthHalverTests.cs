using ArenaConsoleApp.Combat;
using ArenaTests.Heroes;
using Xunit;

namespace ArenaTests.Combat
{
    public class HeroHealthHalverTests
    {
        [Theory]
        // Current health, Expected health
        [InlineData(80, 40)]
        [InlineData(70, 35)]
        [InlineData(85, 42)]
        public void Halves_heros_health(int currentHealth, int expectedHealth)
        {
            var hero = new DummyHero(maxHealth: 100) { CurrentHealth = currentHealth };
            var damager = new HeroHealthHalver();

            damager.Damage(hero);

            Assert.Equal(expectedHealth, hero.Health);
        }

        [Theory]
        // Max health, Health before damage
        [InlineData(100, 50)]
        [InlineData(100, 20)]
        [InlineData(100, 1)]
        public void Kills_hero_when_health_drops_to_fourth_of_max_health(
            int maxHealth,
            int healthBeforeDamage)
        {
            var hero = new DummyHero(maxHealth) { CurrentHealth = healthBeforeDamage };
            var damager = new HeroHealthHalver();

            damager.Damage(hero);

            Assert.True(hero.IsDead());
        }
    }
}
