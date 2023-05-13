using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat.Duel
{
    internal class NoDuel : IDuel
    {
        public void Fight(IHero attacker, IHero defender) { }
    }
}
