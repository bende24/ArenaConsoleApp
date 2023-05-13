using ArenaConsoleApp.Combat.Duel;
using ArenaConsoleApp.Execution;
using ArenaConsoleApp.Heroes;
using ArenaTests.Heroes;
using Xunit;

namespace ArenaTests.Combat.Duel
{
    public class DeathDuelTests
    {
        [Theory]
        [InlineData(DuelParticipant.ATTACKER)]
        [InlineData(DuelParticipant.DEFENDER)]
        public void Only_one_participant_dies(DuelParticipant dies)
        {
            var duelParticipants = new Dictionary<DuelParticipant, IHero>()
            {
                {DuelParticipant.ATTACKER, new DummyHero() },
                {DuelParticipant.DEFENDER, new DummyHero() }
            };
            var duel = new DeathDuel(dies, new Executioner());

            duel.Fight(
                attacker: duelParticipants[DuelParticipant.ATTACKER],
                defender: duelParticipants[DuelParticipant.DEFENDER]);

            var otherParticipant = GetOtherParticipant(duelParticipants, otherThan: dies);
            Assert.True(duelParticipants[dies].IsDead());
            Assert.True(otherParticipant.IsAlive());
        }

        private IHero GetOtherParticipant(Dictionary<DuelParticipant, IHero> participants, DuelParticipant otherThan)
        {
            if(otherThan == DuelParticipant.ATTACKER) return participants[DuelParticipant.DEFENDER];
            return participants[DuelParticipant.ATTACKER];
        }
    }
}
