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
        public void Kills_hero(int health)
        {
            var hero = new DummyHero() { CurrentHealth = health };
            var executioner = new Executioner();

            executioner.Execute(hero);

            Assert.True(hero.IsDead());
        }
    }
}
