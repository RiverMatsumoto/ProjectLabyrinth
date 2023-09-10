using Game.Scripts.Systems.Data;
using Zenject;

namespace Game.Scripts.Systems.Commands
{
    public class AttackCommand : ICommand
    {
        private BattleEntity _target;
        private BattleEntity _user;
        private float _attackData;

        public AttackCommand(BattleEntity target, BattleEntity user)
        {
            _target = target;
            _user = user;
            _attackData = user.stats.strength;
        }
        
        public void Execute()
        {
            UnityEngine.Debug.Log($"Attacked enemy: {_attackData}");
        }
        
        public class Factory : PlaceholderFactory<BattleEntity, BattleEntity, AttackCommand> { }
    }
}
