using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat
{
    internal class HeroHealthHalver : IHeroDamager
    {
        public void Damage(IHero hero)
        {
            var damage = hero.Health / 2;
            hero.TakeDamage(damage);
            if(hero.Health < hero.MaxHealth / 4)
            {
                hero.TakeDamage(hero.Health);
            }
        }
    }
}
