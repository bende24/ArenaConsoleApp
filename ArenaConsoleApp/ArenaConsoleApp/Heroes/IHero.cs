namespace ArenaConsoleApp.Heroes
{
    internal interface IHero
    {
        string Id { get; }
        int Health { get; }

        void TakeDamage(int damage);
        void HealSelf(int heal);
        bool IsDead();
    }
}
