using ArenaConsoleApp.Combat.Duel;
using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Execution;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Rng;

namespace ArenaConsoleApp.CompositionRoots
{
    internal class DuelProviderFactory
    {
        public static IDuelProvider CreateDuelGrid(IRandom rng)
        {
            var executioner = new Executioner();
            var attackerDies = new DeathDuel(dies: DuelParticipant.ATTACKER, executioner);
            var defenderDies = new DeathDuel(dies: DuelParticipant.DEFENDER, executioner);
            var nothingHappens = new NoDuel();
            var archerKnightDuel = new ChanceDuel(duel: defenderDies, new Chance(4, @in: 10, rng));
            var duelGrid = new DuelGrid(
                indexesInGrid: new() { typeof(Archer), typeof(Knight), typeof(Swordsman) },
                grid: new IDuel[,] {
                //              Defender
                //Attacker
                //              Archer              Knight              Swordsman
                /*Archer*/      { defenderDies,     archerKnightDuel,   defenderDies },
                /*Knight*/      { defenderDies,     defenderDies,       attackerDies },
                /*Swordsman*/   { defenderDies,     nothingHappens,     defenderDies },
            });

            return duelGrid;
        }
    }
}
