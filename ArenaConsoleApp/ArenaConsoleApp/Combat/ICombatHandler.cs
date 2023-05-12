using ArenaConsoleApp.Combat.Participants;

namespace ArenaConsoleApp.Combat
{
    internal interface ICombatHandler
    {
        void Fight(CombatParticipants participants);
    }
}
