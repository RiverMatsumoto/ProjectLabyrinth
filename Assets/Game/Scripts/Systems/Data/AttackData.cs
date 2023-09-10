using System;
using System.Collections.Generic;
using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.SkillCommands;
using Game.Scripts.Systems.Skills.AttackTypes;

namespace Game.Scripts.Systems.Data
{
    [Serializable]
    public struct AttackData
    {
        public float damagePower;
        public List<StatusEffectData> StatusEffectDatas { get; set; }
        public PhysicalAttackType PhysicalType { get; }
        public ElementalAttackType ElementalType { get; }
        public BattleEntity Target { get; }
        public BattleEntity User { get; }

        public AttackData(
            float damagePower,
            PhysicalAttackType physicalAttackType,
            ElementalAttackType elementalAttackType,
            BattleEntity target,
            BattleEntity user)
        {
            this.damagePower = damagePower;

            StatusEffectDatas = new List<StatusEffectData>();
            foreach (StatusEffect effect in Enum.GetValues(typeof(StatusEffect)))
            {
                StatusEffectDatas.Add(new StatusEffectData(effect));
            }

            PhysicalType = physicalAttackType;
            ElementalType = elementalAttackType;
            Target = target;
            User = user;
        }

        public override string ToString()
        {
            return $"AttackData: [Target = {Target}, User = {User}, " +
                   $"Attack Type = {PhysicalType.ToString()}, Elemental Type = {ElementalType}]";
        }
    }
}
