using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.ExtensionMethods;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.InputValidations;

namespace ArenaConsoleApp.Arena
{
    internal class Arena : IArena
    {
        private readonly ICombatParticipantsPicker _participantsPicker;

        public Arena(ICombatParticipantsPicker participantsPicker)
        {
            _participantsPicker = participantsPicker ?? throw new ArgumentNullException(nameof(participantsPicker));
        }

        public IHero Fight(IEnumerable<IHero> heroCollection)
        {
            Precondition.Requires(heroCollection.IsNotEmpty());
            var heroes = heroCollection.ToHashSet();

            // Turn:
            while (heroes.Count >= 2)
            {
                // Pick attacker, defender
                var participants = _participantsPicker.Pick(from: heroes);
                Remove(participants, from: heroes);
                // Fight them
                // Rest other heroes
                // Damage combat participants
            }

            return heroes.First();
        }

        private void Remove(CombatParticipants participants, HashSet<IHero> from)
        {
            from.Remove(participants.Attacker);
            from.Remove(participants.Defender);
        }
    }
}
