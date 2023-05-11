namespace ArenaConsoleApp.Heroes
{
    internal abstract class Hero : IHero
    {
        public string Id { get; }

        public int Health { get; protected set; }

        private readonly int _maxHealth;

        protected Hero(string id, int maxHealth)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            _maxHealth = maxHealth;
            Health = maxHealth;
        }

        public void HealSelf(int heal)
        {
            if (heal < 0) return;
            Health += heal;
            if(Health > _maxHealth) Health = _maxHealth;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if(Health < 0) Health = 0;
        }
    }
}
