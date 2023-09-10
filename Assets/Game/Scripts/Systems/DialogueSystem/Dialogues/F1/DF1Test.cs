using System.Collections.Generic;
using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.Commands.Factories;
using Game.Scripts.Systems.MapSystem;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem.Dialogues.F1
{
    public class DF1Test : Dialogue, IInteractable
    {
        public int healAmount = 100;

        [Inject] private SkillCommandProvider _skillCommandProvider;

        protected override void BuildDialogue()
        {
            // Text boxes
            List<string> text = new List<string>();
            List<string> decision0 = new List<string>();
            List<string> healEvent00 = new List<string>();
            List<string> encounterMultiplierEvent01 = new List<string>();
            
            /*
             * Dialogue:
             * Text
             * Decision
             *      a. Event
             *      b. Event
             */
            
            text.Add("You encounter a rainbow colored spring");
            dialogueBuilder.InitializeDialogue(text);
            
            decision0.Add("What do you do?");
            decision0.Add("Drink the spring");
            decision0.Add("Bath in the spring");
            dialogueBuilder.AppendDecisionNode(decision0);
            
            healEvent00.Add($"You drank the spring water and your party Healed by {healAmount.ToString()}");
            encounterMultiplierEvent01.Add("You bathed in the spring and monsters are attracted to your smell." +
                                                " Be careful!");
            ICommand drinksSpringAndHeals = _skillCommandProvider.CreateStaticHeal("John", healAmount);
            ICommand bathesSpringAndMonstersAttracted = _skillCommandProvider.CreateEncounterMultiplier(2.0f, 20);
            dialogueBuilder.TraverseBranchesFromStart(new List<int> {0});
            dialogueBuilder.AppendEventNode(healEvent00, drinksSpringAndHeals);
            dialogueBuilder.AppendEventNode(encounterMultiplierEvent01, bathesSpringAndMonstersAttracted);
        }
    
        public void Interact(InteractionHandler interactionHandler)
        {
            // TODO set up game/story flags
            gameObject.GetComponent<BoxCollider>().enabled = false;
            dialogueBuilder = dialogueBuilderFactory.Create();
            BuildDialogue();
            OpenDialogue();
        }
    }
}
