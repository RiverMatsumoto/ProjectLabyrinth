namespace Game.Scripts.Systems.BattleSystem
{
    public struct Stats
    {
        public int health { get; set; }
        public int techPoints { get; set; }
        public int maxHealth { get; set; }
        public int maxTechPoints { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int vitality { get; set; }
        public int wisdom { get; set; }
        public int agility { get; set; }
        public int luck { get; set; }

        public Stats(int _maxHealth, int _maxTechPoints, int _strength, int _intelligence, 
            int _vitality, int _wisdom, int _agility, int _luck)
        {
            health = _maxHealth;
            techPoints = _maxTechPoints;
            maxHealth = _maxHealth;
            maxTechPoints = _maxTechPoints;
            strength = _strength;
            intelligence = _intelligence;
            vitality = _vitality;
            wisdom = _wisdom;
            agility = _agility;
            luck = _luck;
        }

        public static Stats operator +(Stats s1, Stats s2)
        {
            Stats newStats = new Stats(
                s1.maxHealth + s2.maxHealth,
                s1.maxTechPoints + s2.maxTechPoints,
                s1.strength + s2.strength,
                s1.intelligence, s2.intelligence,
                s1.vitality + s2.vitality,
                s1.wisdom + s2.agility,
                s1.luck + s2.luck
            );
            return newStats;
        }
    }
}