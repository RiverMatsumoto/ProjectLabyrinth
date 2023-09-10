using Game.Scripts.Systems.Data;
using Game.Scripts.Systems.Skills.SkillCore;
using Game.Scripts.Systems.Skills.SkillEffects;
using UnityEngine;

namespace Game.Scripts.Systems.Skills.SkillScripts
{
    public class AttackSkill : Skill
    {
        private BattleEntity _target;
        private BattleEntity _user;
        
        public AttackSkill(SkillParams skillParams) : base(skillParams)
        {
            _user = skillParams.user[0];
            _target = skillParams.target[0];
        }
        
        public override void Execute()
        {
            DamageEffect damageEffect = new DamageEffect
            {
                user = _user,
                target = _target,
                damagePower = 1.0f,
                statusEffectDatas = null
            };
            // TODO implement animation class for attacks?
            Debug.Log("Executed attack skill: " + damageEffect);
        }
    }
}