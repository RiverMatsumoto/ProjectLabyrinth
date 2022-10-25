using System.Collections.Generic;
using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.SkillCommands;

namespace Game.Scripts.Systems 
{
    public class PlayerEntity : IBattleEntity
    {
        public string name { get; private set;  }

        public int Attack // TODO create weapons and add weapon damage to Attack and TechAttack
        {
            get => stats.baseStrength;
        }

        public int MagicAttack
        {
            get => stats.baseIntelligence;
        }

        public int Defense // TODO create armor and add armor defense to Defense and MDefense
        {
            get => stats.baseVitality;
        }

        public int MagicDefense
        {
            get => stats.baseWisdom;
        }

        public List<ISkillCommand> KnownSkills { get; }

        public Stats baseStats { get; private set; }
        public Stats bonusStats { get; private set; }
        public Stats stats { get; }

        public PlayerEntity()
        {
        }
    }
}