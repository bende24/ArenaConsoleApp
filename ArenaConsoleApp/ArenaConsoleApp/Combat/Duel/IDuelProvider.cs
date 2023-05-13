using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat.Duel
{
    internal interface IDuelProvider
    {
        IDuel GetDuelOf(IHero attacker, IHero defender);
    }
}