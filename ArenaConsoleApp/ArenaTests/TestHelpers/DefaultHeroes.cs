using ArenaConsoleApp.Heroes;

namespace ArenaTests.TestHelpers
{
    internal static class DefaultHeroes
    {
        public static IHero Archer { get { return new Archer(""); } }
        public static IHero Knight { get { return new Knight(""); } }
        public static IHero Swordsman { get { return new Swordsman(""); } }
    }
}
