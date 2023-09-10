using System.Collections.Generic;
using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.SkillCommands;

namespace Game.Scripts.Systems.Data 
{
    public class PlayerEntity
    {
        private Data _data;
        public string name
        {
            get => _data.name;
            private set => _data.name = value;
        }

        public int Attack // TODO create weapons and add weapon damage to Attack and TechAttack
        {
            get => _data.stats.strength;
        }

        public int MagicAttack
        {
            get => _data.stats.intelligence;
        }

        public int Defense // TODO create armor and add armor defense to Defense and MDefense
        {
            get => _data.stats.vitality;
        }

        public int MagicDefense
        {
            get => _data.stats.wisdom;
        }

        public List<ICommand> KnownSkills
        {
            get => _data.KnownSkills;
        }
        public Stats stats
        {
            get => _data.stats;
        }
        public Stats baseStats
        {
            get => _data.baseStats;
            private set => _data.baseStats = value;
        }
        public Stats bonusStats
        {
            get => _data.bonusStats;
            private set => _data.bonusStats = value;
        }

        public class Data
        {
            public string name;
            public List<ICommand> KnownSkills;
            public Stats stats;
            public Stats baseStats;
            public Stats bonusStats;
        }
    }
}