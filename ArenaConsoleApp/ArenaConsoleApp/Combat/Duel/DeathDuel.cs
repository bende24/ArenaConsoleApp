using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Execution;
using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat.Duel
{
    internal class DeathDuel : IDuel
    {
        private readonly IExecutioner _executioner;
        private readonly DuelParticipant _dies;

        public DeathDuel(DuelParticipant dies, IExecutioner executioner)
        {
            _executioner = executioner ?? throw new ArgumentNullException(nameof(executioner));
            _dies = dies;
        }

        public void Fight(IHero attacker, IHero defender)
        {
            if (_dies == DuelParticipant.ATTACKER)
            {
                _executioner.Execute(attacker);
            }
            else if (_dies == DuelParticipant.DEFENDER)
            {
                _executioner.Execute(defender);
            }
        }
    }
}
