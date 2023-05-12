using ArenaConsoleApp.Execution;
using ArenaTests.Heroes;
using Xunit;

namespace ArenaTests.Execution
{
    public class ExecutionerTests
    {
        [Theory]
        [InlineData(100)]
        [InlineData(50)]
        [InlineData(23)]
        [InlineData(1)]
        [InlineData(0)]
        public void Kills_hero_when_health_drops_below_quarter_of_max_health(int health)
        {
            var hero = new DummyHero() { CurrentHealth = health };
            var executioner = new Executioner();

            executioner.Execute(hero);

            Assert.True(hero.IsDead());
        }
    }
}
