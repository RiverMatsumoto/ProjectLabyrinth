using Game.Scripts.Systems.BattleSystem.Formulas;
using Game.Scripts.Systems.Data;
using Game.Scripts.Systems.Skills.SkillCore;

namespace Game.Scripts.Systems.Skills.SkillScripts
{
    public class CureSkill : Skill
    {
        private BattleEntity _user;
        private BattleEntity _target;
        
        public CureSkill(SkillParams skillParams) : base(skillParams)
        {
            _user = skillParams.user[0];
            _target = skillParams.target[0];
        }

        public override void Execute()
        {
            // temporary, use HealEffect
            int baseHealAmount = Formulas.CalculateHeal(_user, 20);
            
        }
    }
}