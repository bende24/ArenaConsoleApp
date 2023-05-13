using ArenaConsoleApp.Combat;
using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.ExtensionMethods;
using ArenaConsoleApp.Healers;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.InputValidations;

namespace ArenaConsoleApp.Arena
{
    internal class Arena : IArena
    {
        private readonly ICombatParticipantsPicker _participantsPicker;
        private readonly IMassHealer _massHealer;
        private readonly ICombatAction _combat;

        public Arena(ICombatParticipantsPicker participantsPicker, IMassHealer massHealer, ICombatAction combatAction)
        {
            _participantsPicker = participantsPicker ?? throw new ArgumentNullException(nameof(participantsPicker));
            _massHealer = massHealer ?? throw new ArgumentNullException(nameof(massHealer));
            _combat = combatAction ?? throw new ArgumentNullException(nameof(combatAction));
        }

        public IHero? Fight(HeroCollection heroes)
        {
            Precondition.Requires(heroes.IsNotEmpty());

            while (heroes.Count >= 2)
            {
                var participants = _participantsPicker.Pick(from: heroes);
                Remove(participants, from: heroes);
                _combat.Fight(participants);
                Rest(heroes);
                Add(participants, to: heroes);
            }

            // Determine winner
            return heroes.First();
        }

        private static void Remove(CombatParticipants participants, HeroCollection from)
        {
            participants.All().ForEach(participant => from.Remove(participant));
        }
        private static void Add(CombatParticipants participants, HeroCollection to)
        {
            participants.All().ForEach(participant => to.Add(participant));
        }

        private void Rest(IEnumerable<IHero> heroes) => _massHealer.Heal(heroes);
    }
}
