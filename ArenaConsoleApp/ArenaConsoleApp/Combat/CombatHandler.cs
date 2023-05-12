using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Execution;

namespace ArenaConsoleApp.Combat
{
    internal class CombatHandler : ICombatHandler
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
            // Duel
            _heroDamager.Damage(participants.Attacker);
            _heroDamager.Damage(participants.Defender);

            if(_judge.ShouldBeExecuted(participants.Attacker)) { _executioner.Execute(participants.Attacker); }
            if(_judge.ShouldBeExecuted(participants.Defender)) { _executioner.Execute(participants.Defender); }
        }
    }
}
