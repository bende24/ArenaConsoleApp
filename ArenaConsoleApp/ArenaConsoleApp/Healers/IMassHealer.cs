using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Healers
{
    internal interface IMassHealer
    {
        void Heal(IEnumerable<IHero> heroes);
    }
}
