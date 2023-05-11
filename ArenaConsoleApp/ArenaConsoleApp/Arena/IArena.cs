using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Arena
{
    internal interface IArena
    {
        /// <returns>The winner</returns>
        IHero Fight(IEnumerable<IHero> heroes);
    }
}