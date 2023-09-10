using System;
using System.Collections.Generic;
using Game.Scripts.Systems.BattleSystem.Formulas;
using Game.Scripts.Systems.Data;
using Game.Scripts.Systems.Skills.AttackTypes;

namespace Game.Scripts.Systems.Skills.SkillEffects
{
    [Serializable]
    public class DamageEffect : SkillEffect
    {
        public float damagePower;
        public int damage;
        
        public List<StatusEffectData> statusEffectDatas { get; set; }
        public PhysicalAttackType physicalAttackType;
        public ElementalAttackType elementalAttackType;
        public BattleEntity target;
        public BattleEntity user;

        public override void Execute()
        {
            damage = Formulas.CalculateDamageNormal(this);
        }
    }
}