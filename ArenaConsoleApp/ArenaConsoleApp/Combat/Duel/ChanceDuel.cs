using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Rng;

namespace ArenaConsoleApp.Combat.Duel
{
    internal class ChanceDuel : IDuel
    {
        private readonly IDuel _duel;
        private readonly IChance _chance;

        public ChanceDuel(IDuel duel, IChance chance)
        {
            _duel = duel ?? throw new ArgumentNullException(nameof(duel));
            _chance = chance ?? throw new ArgumentNullException(nameof(chance));
        }

        public void Fight(IHero attacker, IHero defender)
        {
            if (_chance.DoesHappen())
            {
                _duel.Fight(attacker, defender);
            }
        }
    }
}
