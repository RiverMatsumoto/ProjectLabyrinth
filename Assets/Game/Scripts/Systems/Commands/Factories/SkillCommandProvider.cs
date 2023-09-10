using Game.Scripts.Systems.SkillCommands;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.Commands.Factories
{
    public class SkillCommandProvider
    {
        // PROCESS TO MAKE SKILL, INHERIT FROM FACTORY, INSTALL IN CONTAINER
        // ALL CLASSES THAT WANT A SKILLCOMMAND NEED TO HAVE SKILLCOMMANDFACTORIES INJECTED
        
        [Inject] private StaticHealCommand.Factory _staticHealFactory;
        public StaticHealCommand CreateStaticHeal(string target, int healAmount)
        {
            return _staticHealFactory.Create(target, healAmount);
        }

        [Inject] private EncounterMultiplier.Factory _encounterMultiplierFactory;
        public EncounterMultiplier CreateEncounterMultiplier(float multiplier, int maxSteps)
        {
            return _encounterMultiplierFactory.Create(multiplier, maxSteps);
        }

        [Inject] private EnableDialogueCommand.Factory _enableDialogueCommandFactory;

        public EnableDialogueCommand CreateEnableDialogueCommand(BoxCollider dialogueTrigger)
        {
            return _enableDialogueCommandFactory.Create(dialogueTrigger);
        }
    }
}
