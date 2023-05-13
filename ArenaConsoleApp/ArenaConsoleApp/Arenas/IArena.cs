using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Arenas
{
    internal interface IArena
    {
        /// <returns>The winner</returns>
        IHero? Fight(HeroCollection heroes);
    }
}