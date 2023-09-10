using System;

namespace Game.Scripts.Systems.Data
{
    [Serializable]
    public class Stats
    {
        public int level;
        public int health;
        public int techPoints;
        public int maxHealth;
        public int maxTechPoints;
        public int strength;
        public int intelligence;
        public int vitality;
        public int wisdom;
        public int agility;
        public int luck;
        
        public Stats(int level = 0, 
            int maxHealth = 0, 
            int maxTechPoints = 0, 
            int strength = 0, 
            int intelligence = 0,
            int vitality = 0, 
            int wisdom = 0, 
            int agility = 0, 
            int luck = 0)
        {
            this.level = level;
            this.health = maxHealth;
            this.techPoints = maxTechPoints;
            this.maxHealth = maxHealth;
            this.maxTechPoints = maxTechPoints;
            this.strength = strength;
            this.intelligence = intelligence;
            this.vitality = vitality;
            this.wisdom = wisdom;
            this.agility = agility;
            this.luck = luck;
        }

        public Stats(BattleEntityData data)
        {
            level = data.level;
            health = data.maxHealth;
            techPoints = data.maxTechPoints;
            maxHealth = data.maxHealth;
            maxTechPoints = data.maxTechPoints;
            strength = data.strength;
            intelligence = data.intelligence;
            vitality = data.vitality;
            wisdom = data.wisdom;
            agility = data.agility;
            luck = data.luck;
        }

        public void Clear()
        {
            level = 0;
            health = 0;
            techPoints = 0;
            maxHealth = 0;
            maxTechPoints = 0;
            strength = 0;
            intelligence = 0;
            vitality = 0;
            wisdom = 0;
            agility = 0;
            luck = 0;
        }

        public static Stats operator +(Stats stats1, Stats stats2)
        {
            return new Stats
            {
                level = stats1.level + stats2.level,
                health = stats1.health + stats2.health,
                maxHealth = stats1.maxHealth + stats2.maxHealth,
                techPoints = stats1.techPoints + stats2.techPoints,
                maxTechPoints = stats1.maxTechPoints + stats2.maxTechPoints,
                strength = stats1.strength + stats2.strength,
                intelligence = stats1.intelligence + stats2.intelligence,
                vitality = stats1.vitality + stats2.vitality,
                wisdom = stats1.wisdom + stats2.wisdom,
                agility = stats1.agility + stats2.agility,
                luck = stats1.luck + stats2.luck
            };
        }
    }
}