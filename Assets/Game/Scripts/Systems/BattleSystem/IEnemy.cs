using System.Collections.Generic;
using Game.Scripts.Systems.Items;

namespace Game.Scripts.Systems.BattleSystem
{
    public interface IEnemy
    {
        // drops
        public List<IItem> Drops { get; }
    }
}
