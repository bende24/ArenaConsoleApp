using Xunit;

namespace ArenaTests.Heroes
{
    public class HeroTests
    {
        [Theory]
        // Max health, Taken damage, Expected health
        [InlineData(100, 50, 50)]
        [InlineData(100, 18, 82)]
        [InlineData(100, 99, 1)]
        [InlineData(100, 0, 100)]
        [InlineData(100, 100, 0)]
        [InlineData(100, 131, 0)]
        public void Heros_health_after_taking_damage_is_as_expected(int maxHealth, int takenDamage, int expectedHealth)
        {
            var hero = new DummyHero(maxHealth);

            hero.TakeDamage(takenDamage);

            Assert.Equal(expectedHealth, hero.Health);
        }

        [Theory]
        [InlineData(20, false)]
        [InlineData(1, false)]
        [InlineData(0, true)]
        public void Hero_is_dead_when_his_health_is_zero(int health, bool isDead)
        {
            var hero = new DummyHero(100);

            hero.SetHealth(health); 

            Assert.Equal(isDead, hero.IsDead());
        }

        [Theory]
        // Max health, Current health, Healed health, Expected health
        [InlineData(100, 80, 20, 100)]
        [InlineData(100, 100, 40, 100)]
        [InlineData(100, 90, 20, 100)]
        [InlineData(100, 70, 20, 90)]
        [InlineData(100, 70, -20, 70)]
        public void Hero_heals_himself_as_expected(int maxHealth, int currentHealth, int healthToHeal, int expectedHealth)
        {
            var hero = new DummyHero(maxHealth);
            hero.SetHealth(currentHealth);

            hero.HealSelf(healthToHeal);

            Assert.Equal(expectedHealth, hero.Health);
        }
    }
}
