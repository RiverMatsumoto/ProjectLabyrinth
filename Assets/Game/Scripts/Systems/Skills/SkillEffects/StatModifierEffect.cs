using System.Collections.Generic;
using Game.Scripts.Systems.Data;

namespace Game.Scripts.Systems.Skills.SkillEffects
{
    public class StatModifierEffect : SkillEffect
    {
        public List<BattleEntity> battleEntities;
        public Stats statsToAdd;
        public int turnsActive;

        public override void Execute()
        {
            // loop through battle entities and affect them
        }
    }
}