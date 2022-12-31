using System;
using System.Collections.Generic;
using Game.Scripts.Systems.SkillCommands;

namespace Game.Scripts.Systems.BattleSystem
{
    public struct AttackData
    {
        public int FinalAttackDamage { get; set; }
        public List<StatusEffectData> StatusEffectDatas { get; set; }
        public PhysicalAttackType PhysicalType { get; }
        public ElementalAttackType ElementalType { get; }
        public ISkillCommand SkillCommand { get; }
        public IBattleEntity Target { get; }
        public IBattleEntity User { get; }

        public AttackData(PhysicalAttackType physicalAttackType,
            ElementalAttackType elementalAttackType,
            ISkillCommand skillCommand,
            IBattleEntity target,
            IBattleEntity user)

        {
            FinalAttackDamage = 0;

            StatusEffectDatas = new List<StatusEffectData>();
            foreach (StatusEffect effect in Enum.GetValues(typeof(StatusEffect)))
            {
                StatusEffectDatas.Add(new StatusEffectData(effect));
            }

            PhysicalType = physicalAttackType;
            ElementalType = elementalAttackType;
            SkillCommand = skillCommand;
            Target = target;
            User = user;
        }

        public override string ToString()
        {
            return $"AttackData: [Target = {Target}, User = {User}, ]";
        }
    }
}
