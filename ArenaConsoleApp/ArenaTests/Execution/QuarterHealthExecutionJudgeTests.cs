using ArenaConsoleApp.Combat;
using ArenaConsoleApp.Execution;
using ArenaTests.Heroes;
using Xunit;

namespace ArenaTests.Execution
{
    public class QuarterHealthExecutionJudgeTests
    {
        [Theory]
        // Max health, Current health, Should die
        [InlineData(100, 50, false)]
        [InlineData(100, 80, false)]
        [InlineData(100, 100, false)]
        [InlineData(100, 20, true)]
        [InlineData(100, 15, true)]
        [InlineData(100, 1, true)]
        [InlineData(99, 24, true)]
        [InlineData(99, 25, false)]
        public void Hero_should_die_when_health_is_below_the_quarter_of_max_health(
            int maxHealth,
            int currentHealth,
            bool shouldDie)
        {
            var hero = new DummyHero(maxHealth) { CurrentHealth = currentHealth };
            var judge = new QuarterHealthExecutionJudge();

            var result = judge.ShouldExecute(hero);

            Assert.Equal(shouldDie, result);
        }
    }
}
