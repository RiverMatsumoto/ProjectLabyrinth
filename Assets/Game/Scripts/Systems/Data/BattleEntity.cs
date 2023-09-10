using System;
using System.Collections.Generic;
using Game.Scripts.Systems.Skills.SkillCore;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Systems.Data
{
    [Serializable]
    public class BattleEntity
    {
        public string name;
        public List<string> knownSkills;
        public Stats stats;
        public Stats bonusStats;
        public List<float> takedamageModifiers;
        
        public Sprite sprite;

        public BattleEntity(BattleEntityData battleEntityData)
        {
            ParseStats(battleEntityData);
            
        }
        
        private void ParseStats(BattleEntityData battleEntityData)
        {
            name = battleEntityData.name;
            knownSkills = battleEntityData.knownSkills;
            stats = new Stats(battleEntityData);
        }

        public void TakeDamage(int damage)
        {
            foreach (var modifier in takedamageModifiers)
            {
                damage = Mathf.FloorToInt(damage * modifier);
            }

            stats.health -= damage;
        }

        public void TeachSkill(string command)
        {
            knownSkills.Add(command);
        }
    }
}