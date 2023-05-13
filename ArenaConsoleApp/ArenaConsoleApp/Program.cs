using ArenaConsoleApp.Arena;
using ArenaConsoleApp.Combat;
using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.CompositionRoots;
using ArenaConsoleApp.Execution;
using ArenaConsoleApp.Healers;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Loggers;
using ArenaConsoleApp.Rng;

// Composition root
var duelProvider = DuelProviderFactory.CreateDuelGrid(new RandomNumberGenerator());
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
    participantsPicker: new CombatParticipantsPicker(new RandomNumbersGenerator()),
    massHealer: new MassHealer(10),
    combatAction: new CombatLogger(new ConsoleLogger(), combatActions)
);
var heroFactory = new HeroFactory();

// Start of application
try
{
    int numberOfHeroes = 0;
    bool isUserInputCorrect = false;
    while (!isUserInputCorrect)
    {
        Console.Write("How many heroes do you want? ");
        isUserInputCorrect = int.TryParse(Console.ReadLine(), out numberOfHeroes);
        isUserInputCorrect &= numberOfHeroes > 1;
    }

    var heroes = CreateHeroes(numberOfHeroes, heroFactory);

    ConsoleWriteHeroes(heroes);

    var winner = arena.Fight(heroes);

    ConsoleWriteWinner(winner);

    Console.ReadLine();
}
catch (Exception e)
{
    LogError(e);
}
finally { Console.WriteLine("Sorry, something went wrong."); }

static void LogError(Exception e)
{
    Console.WriteLine(e);
}

static void ConsoleWriteWinner(IHero? winner)
{
    if (winner != null)
    {
        Console.WriteLine($"Winner is {winner}!");
    }
    else
    {
        Console.WriteLine("Noone won!");
    }
}

HeroCollection CreateHeroes(int numberOfHeroes, HeroFactory heroFactory)
{
    var heroes = new HeroCollection();

    for (int i = 0; i < numberOfHeroes; i++)
    {
        heroes.Add(heroFactory.CreateRandomHero());
    }

    return heroes;
}

static void ConsoleWriteHeroes(HeroCollection heroes)
{
    Console.Write("Heroes: ");
    foreach (var hero in heroes)
    {
        Console.Write($"{hero}, ");
    }
    Console.WriteLine();
    Console.WriteLine();
}