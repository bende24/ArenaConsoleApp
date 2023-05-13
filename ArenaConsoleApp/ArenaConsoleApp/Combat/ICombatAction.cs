using ArenaConsoleApp.Combat.Participants;

namespace ArenaConsoleApp.Combat
{
    internal interface ICombatAction
    {
        void Fight(CombatParticipants participants);
    }
}
