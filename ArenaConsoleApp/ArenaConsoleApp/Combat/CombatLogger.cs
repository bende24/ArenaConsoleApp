using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Loggers;

namespace ArenaConsoleApp.Combat
{
    internal class CombatLogger : ICombatAction
    {
        private readonly ILogger _logger;
        private readonly ICombatAction _combatAction;

        public CombatLogger(ILogger logger, ICombatAction combatAction)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _combatAction = combatAction ?? throw new ArgumentNullException(nameof(combatAction));
        }

        public void Fight(CombatParticipants participants)
        {
            var attacker = participants.Attacker;
            var defender = participants.Defender;
            var originalAttackerHealth = attacker.Health;
            var originalDefenderHealth = defender.Health;

            _combatAction.Fight(participants);

            _logger.Log($"{attacker} attacks {defender}");
            LogCurrentStateOf(attacker, originalAttackerHealth);
            LogCurrentStateOf(defender, originalDefenderHealth);
        }

        private void LogCurrentStateOf(IHero hero, int originalHealth)
        {
            if (hero.IsAlive())
            {
                _logger.Log($"{hero} lost {originalHealth - hero.Health} health, Current health: {hero.Health}");
            }
            else
            {
                _logger.Log($"{hero} died");
            }
        }
    }
}
