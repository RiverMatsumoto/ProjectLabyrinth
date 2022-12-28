using System.Collections.Generic;
using Game.Scripts.Systems.MapSystem;
using Game.Scripts.Systems.SkillCommands;
using Game.Scripts.Systems.SkillCommands.Factories;
using Sirenix.OdinInspector;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem.Dialogues.F1
{
    public class DF1Test : Dialogue, IInteractable
    {
        public int healAmount = 100;

        [Inject] private SkillCommandProvider _skillCommandProvider;

        protected override void BuildDialogue()
        {
            List<string> text0 = new List<string>();
            List<string> decision00 = new List<string>();
            List<string> healEvent000 = new List<string>();
            List<string> encounterMultiplierEvent001 = new List<string>();
            
            text0.Add("You Encounter Rainbow Colored Spring");
            dialogueBuilder.InitializeDialogue(text0);
            
            decision00.Add("What do you do?");
            decision00.Add("Drink the spring");
            decision00.Add("Bath in the spring");
            dialogueBuilder.AppendDecisionNode(decision00);
            
            healEvent000.Add($"You drank the spring water and your party Healed by {healAmount.ToString()}");
            encounterMultiplierEvent001.Add("You bathed in the spring and monsters are attracted to your smell." +
                                                " Be careful!");
            ISkillCommand drinksSpringAndHeals = _skillCommandProvider.CreateStaticHeal("John", healAmount);
            ISkillCommand bathesSpringAndMonstersAttracted = _skillCommandProvider.CreateEncounterMultiplier(2.0f, 20);
            dialogueBuilder.TraverseBranchesFromStart(new List<int> {0});
            dialogueBuilder.AppendEventNode(healEvent000, drinksSpringAndHeals);
            dialogueBuilder.AppendEventNode(encounterMultiplierEvent001, bathesSpringAndMonstersAttracted);
        }
    
#if UNITY_EDITOR
        [Button]
        public void TestDialogue()
        {
            OpenDialogue();
        }
#endif
        public void Interact(InteractionHandler interactionHandler)
        {
            dialogueBuilder = dialogueBuilderFactory.Create();
            BuildDialogue();
            OpenDialogue();
        }
    }
}
