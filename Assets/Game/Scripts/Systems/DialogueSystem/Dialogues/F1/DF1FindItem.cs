using System.Collections.Generic;
using Game.Scripts.Systems.MapSystem;
using Game.Scripts.Systems.SkillCommands;
using Game.Scripts.Systems.SkillCommands.Factories;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem.Dialogues.F1
{
    public class DF1FindItem : Dialogue, IInteractable
    {
        [Inject] private SkillCommandProvider _skillCommandProvider;
        protected override void BuildDialogue()
        {
            // Text boxes
            List<string> text = new List<string>();
            List<string> decision0 = new List<string>();
            List<string> eventGetItem00 = new List<string>();
            List<string> eventGetItem01 = new List<string>();
            List<string> eventGetItem02 = new List<string>();

            /*
             * Dialogue:
             * Text
             * Decision 3 options
             *      a. Event
             *      b. Event
             *      c. Event
             */
            text.Add("A graceful tree catches your eye.");
            text.Add("Your party considers cutting or climbing the tree.");
            dialogueBuilder.InitializeDialogue(text);
            
            decision0.Add("What does your party do?");
            decision0.Add("Cut down the tree");
            decision0.Add("Climb up the tree");
            decision0.Add("Do Nothing");
            dialogueBuilder.AppendDecisionNode(decision0);
            dialogueBuilder.TraverseBranchesFromStart(new List<int>() { 0 });

            ISkillCommand enableDialogue = _skillCommandProvider.CreateEnableDialogueCommand(gameObject.GetComponent<BoxCollider>());
            // ISkillCommand giveItem = _skillCommandProvider
        }

        public void Interact(InteractionHandler interactionHandler)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            dialogueBuilder = new DialogueBuilder();
            BuildDialogue();
            OpenDialogue();
        }
    }
}
