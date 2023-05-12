using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat.Participants
{
    internal interface ICombatParticipantsPicker
    {
        CombatParticipants Pick(IEnumerable<IHero> from);
    }
}
