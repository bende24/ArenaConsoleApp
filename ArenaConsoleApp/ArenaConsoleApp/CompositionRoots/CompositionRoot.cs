using ArenaConsoleApp.Arenas;
using ArenaConsoleApp.Combat;
using ArenaConsoleApp.Combat.Duel;
using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Execution;
using ArenaConsoleApp.Healers;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Loggers;
using ArenaConsoleApp.Rng;

namespace ArenaConsoleApp.CompositionRoots
{
    internal class CompositionRoot
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

        public static IArena CreateArena(IDuelProvider duelProvider, ILogger logger, IRandoms randoms)
        {
            var postCombatAction = new PostCombatAction(
                new HeroDamager(),
                judge: new QuarterHealthExecutionJudge(),
                new Executioner()
            );
            var combatActions = new CombatActions()
            {
                new DuelCombatAction(duelProvider),
                postCombatAction
            };
            var arena = new Arena(
                participantsPicker: new CombatParticipantsPicker(randoms),
                massHealer: new MassHealer(10),
                combatAction: new CombatLogger(logger, combatActions)
            );
            return arena;
        }
    }
}
