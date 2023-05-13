namespace ArenaConsoleApp.Rng
{
    internal class Chance : IChance
    {
        private readonly int _chance;
        private readonly int _chancesIn;
        private readonly IRandom _random;

        public Chance(int chance, int @in, IRandom random)
        {
            _chance = chance;
            _chancesIn = @in;
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public bool DoesHappen()
        {
            var number = _random.GenerateNumber(0, _chancesIn);
            return number < _chance;
        }
    }
}
