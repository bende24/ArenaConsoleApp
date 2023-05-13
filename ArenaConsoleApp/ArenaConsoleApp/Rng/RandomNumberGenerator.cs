namespace ArenaConsoleApp.Rng
{
    internal class RandomNumberGenerator : IRandom
    {
        public int GenerateNumber(int inclusiveMin, int exclusiveMax)
        {
            var random = new Random();
            return random.Next(inclusiveMin, exclusiveMax);
        }
    }
}
