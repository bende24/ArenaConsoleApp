namespace ArenaConsoleApp.Heroes
{
    internal class HeroFactory
    {
        private int _archerId = 1;
        private int _knightId = 1;
        private int _swordsmanId = 1;

        private delegate IHero HeroFactoryFunction();
        private HeroFactoryFunction[] _heroFactories;

        public HeroFactory()
        {
            _heroFactories = new HeroFactoryFunction[]
            {
                new HeroFactoryFunction(CreateArcher),
                new HeroFactoryFunction(CreateKnight),
                new HeroFactoryFunction(CreateSwordsman),
            };
        }

        public IHero CreateArcher()
        {
            return new Archer($"Archer {_archerId++}");
        }

        public IHero CreateKnight()
        {
            return new Knight($"Knight {_knightId++}");
        }

        public IHero CreateSwordsman()
        {
            return new Swordsman($"Swordsman {_swordsmanId++}");
        }

        public IHero CreateRandomHero()
        {
            var random = new Random();
            var index = random.Next(_heroFactories.Length);
            return _heroFactories[index]();
        }
    }
}
