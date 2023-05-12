using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.InputValidations;
using ArenaConsoleApp.Rng;

namespace ArenaConsoleApp.Combat.Participants
{
    internal class CombatParticipantsPicker : ICombatParticipantsPicker
    {
        private readonly IRandoms _randomNumbersGenerator;

        public CombatParticipantsPicker(IRandoms randomNumbersGenerator)
        {
            _randomNumbersGenerator = randomNumbersGenerator ?? throw new ArgumentNullException(nameof(randomNumbersGenerator));
        }

        public CombatParticipants Pick(IEnumerable<IHero> heroes)
        {
            Precondition.Requires(heroes.Count() >= 2);

            var numbers = _randomNumbersGenerator.GenerateNumbers(0, heroes.Count(), 2);

            return new CombatParticipants(heroes.ElementAt(numbers[0]), heroes.ElementAt(numbers[1]));
        }
    }
}