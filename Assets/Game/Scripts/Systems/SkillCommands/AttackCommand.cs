using Game.Scripts.Systems.BattleSystem;
using Zenject;

namespace Game.Scripts.Systems.SkillCommands
{
    public class AttackCommand : ISkillCommand
    {
        private IBattleEntity _target;
        private IBattleEntity _user;
        private float _attackData;

        public AttackCommand(IBattleEntity target, IBattleEntity user)
        {
            _target = target;
            _user = user;
            _attackData = user.Attack;
        }
        
        public void Execute()
        {
            UnityEngine.Debug.Log($"Attacked enemy: {_attackData}");
        }
        
        public class Factory : PlaceholderFactory<AttackCommand> { }
    }
}
