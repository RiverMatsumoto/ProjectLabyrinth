using Game.Scripts.Systems.BattleSystem;

namespace Game.Scripts.Systems.Items
{
    public interface IEquipable
    {
        public Stats bonusStats { get; set; }
        public int Attack { get; }
        public int Defense { get; }
    }
}
