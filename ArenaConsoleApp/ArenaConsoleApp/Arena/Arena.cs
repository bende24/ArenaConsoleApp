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

        public Arena(ICombatParticipantsPicker participantsPicker, IMassHealer massHealer)
        {
            _participantsPicker = participantsPicker ?? throw new ArgumentNullException(nameof(participantsPicker));
            _massHealer = massHealer ?? throw new ArgumentNullException(nameof(massHealer));
        }

        public IHero? Fight(HeroCollection heroes)
        {
            Precondition.Requires(heroes.IsNotEmpty());

            while (heroes.Count >= 2)
            {
                // Turn:
                var participants = _participantsPicker.Pick(from: heroes);
                Remove(participants, from: heroes);
                // Fight them => Damage combat participants
                Rest(heroes);
                Add(participants, to: heroes);
            }

            return heroes.First();
        }

        private static void Remove(CombatParticipants participants, HeroCollection from)
        {
            from.Remove(participants.Attacker);
            from.Remove(participants.Defender);
        }
        private static void Add(CombatParticipants participants, HeroCollection to)
        {
            to.Add(participants.Attacker);
            to.Add(participants.Defender);
        }

        private void Rest(IEnumerable<IHero> heroes) => _massHealer.Heal(heroes);
    }
}
