using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Execution;
using ArenaConsoleApp.ExtensionMethods;

namespace ArenaConsoleApp.Combat
{
    internal class PostCombatAction : ICombatAction
    {
        private readonly IHeroDamager _heroDamager;
        private readonly IExecutionJudge _judge;
        private readonly IExecutioner _executioner;

        public PostCombatAction(IHeroDamager heroDamager, IExecutionJudge judge, IExecutioner executioner)
        {
            _heroDamager = heroDamager ?? throw new ArgumentNullException(nameof(heroDamager));
            _judge = judge ?? throw new ArgumentNullException(nameof(judge));
            _executioner = executioner ?? throw new ArgumentNullException(nameof(executioner));
        }

        public void Fight(CombatParticipants participants)
        {
            Damage(participants);

            KillIfShouldDie(participants);
        }

        private void KillIfShouldDie(CombatParticipants participants)
        {
            participants.All().ForEach(participant =>
            {
                if (_judge.ShouldExecute(participant)) { _executioner.Execute(participant); }
            });
        }

        private void Damage(CombatParticipants participants)
        {
            participants.All().ForEach(participant => _heroDamager.Damage(participant));
        }
    }
}
