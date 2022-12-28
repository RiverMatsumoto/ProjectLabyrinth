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
        Stats stats { get; }
        Stats baseStats { get; }
        Stats bonusStats { get; }
        
        // TODO Battle entities have a list of SkillCommands they know
        List<ISkillCommand> KnownSkills { get; }

        public void TeachSkill(ISkillCommand skill)
        {
            KnownSkills.Add(skill);
        }
    }
}