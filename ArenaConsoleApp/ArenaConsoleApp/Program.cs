﻿using ArenaConsoleApp.Heroes;

// Composition root
var heroFactory = new HeroFactory();


// Start of application
int numberOfHeroes = 0;
bool isUserInputInt = false;
while(!isUserInputInt){
    Console.Write("How many heroes do you want? ");
    isUserInputInt = int.TryParse(Console.ReadLine(), out numberOfHeroes);
}

var heroes = CreateHeroes(numberOfHeroes, heroFactory);


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