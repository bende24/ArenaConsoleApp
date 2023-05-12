namespace ArenaConsoleApp.Heroes
{
    internal class HeroCollection : HashSet<IHero>
    {
        public new void Add(IHero hero)
        {
            if(hero.IsAlive()) { base.Add(hero); }
        }
    }
}
