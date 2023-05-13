using ArenaConsoleApp.ExtensionMethods;

namespace ArenaConsoleApp.Rng
{
    internal class RandomNumbersGenerator : IRandoms
    {
        public int[] GenerateNumbers(int inclusiveMin, int exclusiveMax, int count)
        {
            var list = Enumerable.Range(inclusiveMin, exclusiveMax).ToList().Shuffle();
            return list.Take(count).ToArray();
        }
    }
}
