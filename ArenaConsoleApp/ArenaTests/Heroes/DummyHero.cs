using ArenaConsoleApp.Heroes;

namespace ArenaTests.Heroes
{
    internal class DummyHero : Hero
    {
        public DummyHero(string id, int maxHealth) : base(id, maxHealth)
        {
        }
        public DummyHero(int maxHealth) : base("ID", maxHealth)
        {
        }
        public DummyHero() : base("ID", 100)
        {
        }

        public void SetHealth(int health) { Health = health; }
    }
}
