using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Execution
{
    internal class Executioner : IExecutioner
    {
        public void Execute(IHero hero)
        {
            hero.TakeDamage(hero.Health);
        }
    }
}
