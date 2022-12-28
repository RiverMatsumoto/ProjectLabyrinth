using System;
using Game.Scripts.Systems.BattleSystem;
using Sirenix.Serialization;
using Zenject;

namespace Game.Scripts.Systems.SkillCommands
{
    [Serializable]
    public class StaticHealCommand : ISkillCommand
    {
        // [OdinSerialize]
        private string _target;
        // [OdinSerialize]
        private int _healAmount;
        public StaticHealCommand(string target, int amount) // TODO implement battleentity dummies for testing
        {
            _target = target;
            _healAmount = amount;
        }
        
        public void Execute()
        {
            UnityEngine.Debug.Log($"{_target} was healed by {_healAmount}");
        }

        // string: target, int: amount
        public class Factory : PlaceholderFactory<string, int, StaticHealCommand> { }
    }
}
