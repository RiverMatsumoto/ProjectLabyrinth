namespace Game.Scripts.Systems.Data
{
    public struct StatusEffectData
    {
        public StatusEffect statusEffect;
        public float chance;

        public StatusEffectData(StatusEffect statusEffect = StatusEffect.None, float chance = 0)
        {
            this.statusEffect = statusEffect;
            this.chance = chance;
        }
    }
}