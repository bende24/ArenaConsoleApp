using ArenaConsoleApp.ExtensionMethods;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.InputValidations;

namespace ArenaConsoleApp.Arena
{
    internal class Arena : IArena
    {
        public IHero Fight(IEnumerable<IHero> heroes)
        {
            Precondition.Requires(heroes.IsNotEmpty());

            // Turn:
            // Pick attacker, defender
            // Fight them
            // Rest other heroes
            // Damage combat participants

            return heroes.First();
        }
    }
}
