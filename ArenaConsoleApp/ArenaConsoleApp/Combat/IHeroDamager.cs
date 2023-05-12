using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat
{
    internal interface IHeroDamager
    {
        void Damage(IHero hero);
    }
}