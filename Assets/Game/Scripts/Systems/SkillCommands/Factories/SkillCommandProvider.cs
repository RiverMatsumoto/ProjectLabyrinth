using Game.Scripts.Systems.BattleSystem;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.SkillCommands.Factories
{
    public class SkillCommandProvider
    {
        // PROCESS TO MAKE SKILL, INHERIT FROM FACTORY, INSTALL IN CONTAINER
        // ALL CLASSES THAT WANT A SKILLCOMMAND NEED TO HAVE SKILLCOMMANDFACTORIES INJECTED
        
        [Inject] private StaticHealCommand.Factory staticHealFactory;
        public StaticHealCommand CreateStaticHeal(string target, int healAmount)
        {
            return staticHealFactory.Create(target, healAmount);
        }

        [Inject] private EncounterMultiplier.Factory encounterMultiplierFactory;
        public EncounterMultiplier CreateEncounterMultiplier(float multipler, int maxSteps)
        {
            UnityEngine.Debug.Log($"{multipler}, {maxSteps}");
            EncounterMultiplier encounterMultiplier = encounterMultiplierFactory.Create(multipler, maxSteps);
            UnityEngine.Debug.Log($"{encounterMultiplier}");
            return encounterMultiplier;
        }
    }
}
