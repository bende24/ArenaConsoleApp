using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat.Participants
{
    internal record CombatParticipants(IHero Attacker, IHero Defender)
    {
        public IEnumerable<IHero> All()
        {
            return new IHero[] { Attacker, Defender };
        }
    }
}
