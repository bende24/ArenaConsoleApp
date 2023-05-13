using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Heroes;
using ArenaTests.TestHelpers;
using Xunit;

namespace ArenaTests.Heroes
{
    public class ArcherCombatTests
    {
        [Fact]
        public void Attacks_archer_defender_dies()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Archer, Defender: DefaultHeroes.Archer);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules();

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsDead());
        }

        [Fact]
        public void Attacks_swordsman_defender_dies()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Archer, Defender: DefaultHeroes.Swordsman);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules();

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsDead());
        }

        [Fact]
        public void Attacks_knight_defender_dies()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Archer, Defender: DefaultHeroes.Knight);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules(randomGeneratedNumber: 2); // Chance to die 1 - 10

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsDead());
        }

        [Fact]
        public void Attacks_knight_defender_blocks()
        {
            var participants = new CombatParticipants(Attacker: DefaultHeroes.Archer, Defender: DefaultHeroes.Knight);
            var duelCombat = DuelCombatActionProvider.GetWithRealDuelRules(randomGeneratedNumber: 7); // Chance to die 1 - 10

            duelCombat.Fight(participants);

            Assert.True(participants.Attacker.IsAlive());
            Assert.True(participants.Defender.IsAlive());
        }
    }
}
