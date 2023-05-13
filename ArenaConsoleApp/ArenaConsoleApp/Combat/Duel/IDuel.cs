using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat.Rules
{
    internal interface IDuel
    {
        void Fight(IHero attacker, IHero defender);
    }
}
