namespace Game.Scripts.Systems.BattleSystem
{
    public struct StatusEffectData
    {
        public StatusEffect statusEffect;
        public float chance;
        public bool isTriggered;

        public StatusEffectData(StatusEffect statusEffect = StatusEffect.None, float chance = 0, bool isTriggered = false)
        {
            this.statusEffect = statusEffect;
            this.chance = chance;
            this.isTriggered = isTriggered;
        }
    }
}