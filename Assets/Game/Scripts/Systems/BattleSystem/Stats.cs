namespace Game.Scripts.Systems.BattleSystem
{
    public struct Stats
    {
        public int health { get; set; }
        public int techPoints { get; set; }
        public int baseMaxHealth { get; set; }
        public int baseMaxTechPoints { get; set; }
        public int baseStrength { get; set; }
        public int baseIntelligence { get; set; }
        public int baseVitality { get; set; }
        public int baseWisdom { get; set; }
        public int baseAgility { get; set; }
        public int baseLuck { get; set; }
        public int bonusMaxHealth { get; set; }
        public int bonusMaxTechPoints { get; set; }
        public int bonusStrength { get; set; }
        public int bonusIntelligence { get; set; }
        public int bonusVitality { get; set; }
        public int bonusWisdom { get; set; }
        public int bonusAgility { get; set; }
        public int bonusLuck { get; set; }

        public Stats(int _baseMaxHealth, int _baseMaxTechPoints, int _baseStrength, int _baseIntelligence, 
            int _baseVitality, int _baseWisdom, int _baseAgility, int _baseLuck)
        {
            health = _baseMaxHealth;
            techPoints = _baseMaxTechPoints;
            baseMaxHealth = _baseMaxHealth;
            baseMaxTechPoints = _baseMaxTechPoints;
            baseStrength = _baseStrength;
            baseIntelligence = _baseIntelligence;
            baseVitality = _baseVitality;
            baseWisdom = _baseWisdom;
            baseAgility = _baseAgility;
            baseLuck = _baseLuck;
            bonusMaxHealth = 0;
            bonusMaxTechPoints = 0;
            bonusStrength = 0;
            bonusIntelligence = 0;
            bonusVitality = 0;
            bonusWisdom = 0;
            bonusAgility = 0;
            bonusLuck = 0;
        }
    }
}