using System;
using System.Collections.Generic;
using ModestTree;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    [Serializable]
    public class DialogueNode
    {
        [SerializeField] public IList<DialogueNode> Branches;
        [SerializeField] public IList<string> Textboxes;
        [SerializeField] public DialogueType dialogueType;
        public const int MAX_CHARS = 400; // Arbitrary, but test max number of characters later with fonts and such
        protected DialogueSystem DialogueSystem;
        protected IDisposable Subscription;

        public DialogueNode(DialogueSystem dialogueSystem, DialogueType dialogueType, IList<string> textboxes = null)
        {
            DialogueSystem = dialogueSystem;
            this.dialogueType = dialogueType;
            Branches = new List<DialogueNode>();
            this.Textboxes = textboxes;
        }

        public virtual void OpenDialogue()
        {
            Subscription = DialogueSystem.dialogueSectionFinishedEvent.Subscribe(branch => TryNextDialogue(branch));
            DialogueSystem.OpenDialogue(this);
        }

        public virtual void TryNextDialogue(int branch = 0)
        {
            Subscription.Dispose();
            if (Branches.Count == 0) return;

            Branches[branch].OpenDialogue();
        }

        public void AddBranch(DialogueNode node)
        {
            Branches.Add(node);
        }
    }
}
