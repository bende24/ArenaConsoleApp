using ArenaConsoleApp.CompositionRoots;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Loggers;
using ArenaConsoleApp.Rng;

// Composition root
var duelProvider = CompositionRoot.CreateDuelGrid(new RandomNumberGenerator());
var arena = CompositionRoot.CreateArena(duelProvider, new ConsoleLogger(), new RandomNumbersGenerator());

var heroFactory = new HeroFactory();

// Start of application
int numberOfHeroes = 0;
bool isUserInputCorrect = false;
while (!isUserInputCorrect)
{
    Console.Write("How many heroes do you want? ");
    isUserInputCorrect = int.TryParse(Console.ReadLine(), out numberOfHeroes);
    isUserInputCorrect &= numberOfHeroes > 1;
}

var heroes = CreateHeroes(numberOfHeroes, heroFactory);

var winner = arena.Fight(heroes);

LogWinner(winner);

Console.ReadLine();


HeroCollection CreateHeroes(int numberOfHeroes, HeroFactory heroFactory)
{
    var heroes = new HeroCollection();

    for (int i = 0; i < numberOfHeroes; i++)
    {
        heroes.Add(heroFactory.CreateRandomHero());
    }

    return heroes;
}

static void LogWinner(IHero? winner)
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