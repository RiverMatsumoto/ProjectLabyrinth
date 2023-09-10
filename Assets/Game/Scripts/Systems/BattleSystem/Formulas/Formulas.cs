using Game.Scripts.Systems.Data;
using Game.Scripts.Systems.Skills.SkillEffects;

namespace Game.Scripts.Systems.BattleSystem.Formulas
{
    public static class Formulas
    {
        public static int CalculateDamageNormal(DamageEffect damageEffect)
        {
            return 0;
        }

        public static int CalculateDamageDecrease()
        {
            return 0;
        }

        public static int CalculateHeal(BattleEntity user, int healPower)
        {
            return healPower * ((160 * user.stats.intelligence) / 160);
        }
    }
}