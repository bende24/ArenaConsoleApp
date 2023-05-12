using ArenaConsoleApp.ExtensionMethods;
using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Combat
{
    internal class HeroDamager : IHeroDamager
    {
        public void Damage(IHero hero)
        {
            if(hero.Health == 0) { return; }
            
            var health = hero.Health;
            if (health.IsOdd()) { health += 1; }
            var damage = health / 2;
            hero.TakeDamage(damage);
        }
    }
}
