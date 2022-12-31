using System.Collections.Generic;
using Game.Scripts.Systems.SkillCommands;
using UnityEngine;

namespace Game.Scripts.Systems.BattleSystem
{
    public class CharacterEntity : IBattleEntity
    {
        public string name { get; }
        public int Attack { get; }
        public int MagicAttack { get; }
        public int Defense { get; }
        public int MagicDefense { get; }

        public Stats stats
        {
            get => baseStats + bonusStats;
        }

        public Stats baseStats { get; }
        public Stats bonusStats { get; }
        
        // equip 
        
        public List<ISkillCommand> KnownSkills { get; }
    }
}
