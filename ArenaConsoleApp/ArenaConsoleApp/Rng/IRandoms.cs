namespace ArenaConsoleApp.Rng
{
    internal interface IRandoms
    {
        int[] GenerateNumbers(int inclusiveMin, int exclusiveMax, int count);
    }
}
