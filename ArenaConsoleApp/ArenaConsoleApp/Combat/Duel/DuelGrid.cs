using ArenaConsoleApp.Combat.Rules;
using ArenaConsoleApp.Heroes;
using ArenaConsoleApp.InputValidations;

namespace ArenaConsoleApp.Combat.Duel
{
    internal class DuelGrid : IDuelProvider
    {
        private readonly IDuel[,] _grid;
        private readonly Dictionary<Type, int> _indexesInGrid;

        public DuelGrid(HashSet<Type> indexesInGrid, IDuel[,] grid)
        {
            var indexes = indexesInGrid ?? throw new ArgumentNullException(nameof(indexesInGrid));
            _indexesInGrid = new();
            FillIndexesInGrid(indexes);
            _grid = grid ?? throw new ArgumentNullException(nameof(grid));
        }

        public IDuel GetDuelOf(IHero attacker, IHero defender)
        {
            Precondition.Requires(Contains(attacker));
            Precondition.Requires(Contains(defender));

            return _grid[GetIndex(attacker), GetIndex(defender)];
        }

        private bool Contains(IHero hero)
        {
            return _indexesInGrid.ContainsKey(hero.GetType());
        }

        private int GetIndex(IHero hero)
        {
            return _indexesInGrid[hero.GetType()];
        }

        private void FillIndexesInGrid(HashSet<Type> indexes)
        {
            int i = 0;
            foreach (var type in indexes)
            {
                _indexesInGrid[type] = i++;
            }
        }
    }
}
