using Game.Scripts.Systems.BattleSystem;
using UnityEngine;

namespace Game.Scripts.Systems.SkillCommands
{
    public class AttackCommand : ISkillCommand
    {
        private IBattleEntity _target;
        private IBattleEntity _user;
        private AttackData _attackData;

        public AttackCommand(IBattleEntity target, IBattleEntity user)
        {
            _target = target;
            _user = user;
        }
        
        public void Execute()
        {
            UnityEngine.Debug.Log("Attacked enemy");
        }
    }
}
