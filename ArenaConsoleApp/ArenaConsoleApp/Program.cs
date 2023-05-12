using ArenaConsoleApp.Arena;
using ArenaConsoleApp.Combat;
using ArenaConsoleApp.Combat.Participants;
using ArenaConsoleApp.Execution;
using ArenaConsoleApp.Healers;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.Rng;

// Composition root
var heroFactory = new HeroFactory();
var combatHandler = new CombatHandler(
    new HeroDamager(),
    judge: new QuarterHealthExecutionJudge(),
    new Executioner()
);
var arena = new Arena(
    participantsPicker: new CombatParticipantsPicker(new RandomNumbersGenerator()),
    massHealer: new MassHealer(10),
    combatHandler
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

var heroes = new HeroCollection();
heroes.UnionWith(CreateHeroes(numberOfHeroes, heroFactory));

var winner = arena.Fight(heroes);

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