using ArenaConsoleApp.Heroes;

namespace ArenaConsoleApp.Healers
{
    internal class MassHealer : IMassHealer
    {
        private readonly int _amountToHeal;

        public MassHealer(int amountToHeal)
        {
            _amountToHeal = amountToHeal;
        }

        public void Heal(IEnumerable<IHero> heroes)
        {
            foreach (var hero in heroes)
            {
                hero.HealSelf(_amountToHeal);
            }
        }
    }
}
