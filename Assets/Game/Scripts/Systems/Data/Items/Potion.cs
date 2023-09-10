using Game.Scripts.Systems.SkillCommands;
using Zenject;

namespace Game.Scripts.Systems.Data.Items
{
    public class Potion
    {
        private StaticHealCommand.Factory _staticHealFactory;
        private readonly BattleEntity _target;

        // TODO probably needs the player menu to select a battle entity
        public Potion(BattleEntity target)
        {
            _target = target;
        }

        public void Use()
        {
            // select battle entity, pass in an Action to execute command
            _staticHealFactory.Create("Johnny", 30).Execute();
            UnityEngine.Debug.Log("POTION HEALED PLAYER");
        }

        public class Factory : PlaceholderFactory<Potion> { }
    }
}
