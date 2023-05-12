using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Execution
{
    internal interface IExecutionJudge
    {
        bool ShouldBeExecuted(IHero hero);
    }
}
