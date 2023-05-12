using ArenaConsoleApp.ExtensionMethods;
using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Execution
{
    internal class QuarterHealthExecutionJudge : IExecutionJudge
    {
        public bool ShouldBeExecuted(IHero hero)
        {
            var maxHealth = hero.MaxHealth;
            if(maxHealth.IsOdd()) { maxHealth += 1; }
            return hero.Health < maxHealth / 4;
        }
    }
}
