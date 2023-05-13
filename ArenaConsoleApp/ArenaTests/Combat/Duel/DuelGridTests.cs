using ArenaConsoleApp.Combat.Duel;
using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Heroes;
using ArenaTests.Heroes;
using Xunit;

namespace ArenaTests.Combat.Duel
{
    public class DuelGridTests
    {
        [Fact]
        public void Throws_exception_when_it_doesnt_contain_attacker_or_defender()
        {
            var archerGrid = new DuelGrid(new() { typeof(Archer) }, new IDuel[,] { });

            // Doesn't contain attacker
            Assert.Throws<Exception>(() => { archerGrid.GetDuelOf(new DummyHero(), new Archer("")); });
            // Doesn't contain defender
            Assert.Throws<Exception>(() => { archerGrid.GetDuelOf(new Archer(""), new DummyHero()); });
        }
    }
}
