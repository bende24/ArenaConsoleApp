using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Execution
{
    internal interface IExecutionJudge
    {
        bool ShouldExecute(IHero hero);
    }
}
