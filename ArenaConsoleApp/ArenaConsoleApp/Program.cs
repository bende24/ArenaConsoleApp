using ArenaConsoleApp.Arena;
using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Healers;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Rng;

// Composition root
var heroFactory = new HeroFactory();
var arena = new Arena(
    participantsPicker: new CombatParticipantsPicker(new RandomNumbersGenerator()),
    massHealer: new MassHealer(10)
);

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

arena.Fight(heroes);

Console.ReadLine();


IEnumerable<IHero> CreateHeroes(int numberOfHeroes, HeroFactory heroFactory)
{
    var heroes = new List<IHero>();

    for (int i = 0; i < numberOfHeroes; i++)
    {
        heroes.Add(heroFactory.CreateRandomHero());
    }

    return heroes;
}