using System.Collections.Generic;
using Game.Scripts.Systems.Items;
using Game.Scripts.Systems.SkillCommands;

namespace Game.Scripts.Systems.BattleSystem
{
    public interface IBattleEntity
    {
        string name { get; }
        int Attack { get; }
        int MagicAttack { get; }
        int Defense { get; }
        int MagicDefense { get; }
        Stats baseStats { get; }
        Stats bonusStats { get; }
        Stats stats { get; }
        
        // TODO Battle entities have a list of SkillCommands they know
        List<ISkillCommand> KnownSkills { get; }

        public bool TryEquip(IEquipable equipment)
        {
            return false;
        }

        public void TeachSkill(ISkillCommand skill)
        {
            KnownSkills.Add(skill);
        }
    }
}