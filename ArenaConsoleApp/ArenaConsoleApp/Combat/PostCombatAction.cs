using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Execution;
using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat
{
    internal class CombatHandler : ICombatAction
    {
        private readonly IHeroDamager _heroDamager;
        private readonly IExecutionJudge _judge;
        private readonly IExecutioner _executioner;

        public CombatHandler(IHeroDamager heroDamager, IExecutionJudge judge, IExecutioner executioner)
        {
            _heroDamager = heroDamager ?? throw new ArgumentNullException(nameof(heroDamager));
            _judge = judge ?? throw new ArgumentNullException(nameof(judge));
            _executioner = executioner ?? throw new ArgumentNullException(nameof(executioner));
        }

        public void Fight(CombatParticipants participants)
        {
            Damage(participants);

            KillIfShouldDie(participants.Attacker);
            KillIfShouldDie(participants.Defender);
        }

        private void KillIfShouldDie(IHero hero)
        {
            if (_judge.ShouldExecute(hero)) { _executioner.Execute(hero); }
        }

        private void Damage(CombatParticipants participants)
        {
            _heroDamager.Damage(participants.Attacker);
            _heroDamager.Damage(participants.Defender);
        }
    }
}
