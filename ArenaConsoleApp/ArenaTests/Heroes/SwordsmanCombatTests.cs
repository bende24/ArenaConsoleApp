using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Heroes;
using ArenaTests.TestHelpers;
using Xunit;

namespace ArenaTests.Heroes
{
    public class SwordsmanCombatTests
    {
        [Fact]
        public void Attacks_archer_defender_dies()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Swordsman, Defender: DefaultHeroes.Archer);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules();

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsDead());
        }

        [Fact]
        public void Attacks_knight_nothing_happens()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Swordsman, Defender: DefaultHeroes.Knight);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules();

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsAlive());
        }

        [Fact]
        public void Attacks_swordsman_defender_dies()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Swordsman, Defender: DefaultHeroes.Swordsman);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules();

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsDead());
        }
    }
}
