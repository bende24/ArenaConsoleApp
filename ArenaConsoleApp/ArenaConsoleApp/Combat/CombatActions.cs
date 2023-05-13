using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.ExtensionMethods;
using System.Collections.ObjectModel;

namespace ArenaConsoleApp.Combat
{
    internal class CombatActions : Collection<ICombatAction>, ICombatAction
    {
        public void Fight(CombatParticipants participants)
        {
            Items.ForEach(action => action.Fight(participants));
        }
    }
}
