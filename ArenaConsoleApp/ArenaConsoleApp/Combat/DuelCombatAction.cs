using ArenaConsoleApp.Combat.Duel;
using ArenaConsoleApp.Combat.Participants;

namespace ArenaConsoleApp.Combat
{
    internal class DuelCombatAction : ICombatAction
    {
        private readonly IDuelProvider _duelProvider;

        public DuelCombatAction(IDuelProvider duelProvider)
        {
            _duelProvider = duelProvider ?? throw new ArgumentNullException(nameof(duelProvider));
        }

        public void Fight(CombatParticipants participants)
        {
            var attacker = participants.Attacker;
            var defender = participants.Defender;
            var duel = _duelProvider.GetDuelOf(attacker, defender);
            duel.Fight(attacker, defender);
        }
    }
}
