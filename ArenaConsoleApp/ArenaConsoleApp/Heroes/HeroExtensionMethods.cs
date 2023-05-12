namespace ArenaConsoleApp.Heroes
{
    internal static class HeroExtensionMethods
    {
        public static bool IsAlive(this IHero hero)
        {
            return !hero.IsDead();
        }
    }
}
