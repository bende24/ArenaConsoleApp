using ArenaConsoleApp.Combat.Participants;
using ArenaTests.TestHelpers;
using ArenaConsoleApp.Heroes;
using Xunit;

namespace ArenaTests.Heroes
{
    public class KnightCombatTests
    {
        [Fact]
        public void Attacks_archer_defender_dies()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Knight, Defender: DefaultHeroes.Archer);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules();

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsDead());
        }

        [Fact]
        public void Attacks_swordsman_attacker_dies()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Knight, Defender: DefaultHeroes.Swordsman);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules();

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsDead());
            Assert.True(participants.Defender.IsAlive());
        }
        [Fact]
        public void Attacks_knight_defender_dies()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Knight, Defender: DefaultHeroes.Knight);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules();

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsDead());
        }
    }
}
