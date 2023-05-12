using ArenaConsoleApp.Combat.Participants;

namespace ArenaConsoleApp.Combat
{
    internal class CombatHandler : ICombatHandler
    {
        private readonly IHeroDamager _heroDamager;

        public CombatHandler(IHeroDamager heroDamager)
        {
            _heroDamager = heroDamager ?? throw new ArgumentNullException(nameof(heroDamager));
        }

        public void Fight(CombatParticipants participants)
        {
            throw new NotImplementedException();
        }
    }
}
