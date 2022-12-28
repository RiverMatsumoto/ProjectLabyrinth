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
        [SerializeField] public IList<DialogueNode> branches;
        [SerializeField] public IList<string> textboxes;
        [SerializeField] public DialogueType dialogueType;
        public const int MAX_CHARS = 400; // Arbitrary, but test max number of characters later with fonts and such
        protected DialogueSystem _dialogueSystem;
        protected IDisposable subscription;

        public DialogueNode(DialogueSystem dialogueSystem, DialogueType dialogueType, IList<string> textboxes = null)
        {
            _dialogueSystem = dialogueSystem;
            this.dialogueType = dialogueType;
            branches = new List<DialogueNode>();
            this.textboxes = textboxes;
        }

        public virtual void OpenDialogue()
        {
            subscription = _dialogueSystem.dialogueSectionFinishedEvent.Subscribe(branch => TryNextDialogue(branch));
            _dialogueSystem.OpenDialogue(this);
        }

        public virtual void TryNextDialogue(int branch = 0)
        {
            subscription.Dispose();
            if (branches.Count <= 0) return;
            
            branches[branch].OpenDialogue();
        }

        public void AddBranch(DialogueNode node)
        {
            branches.Add(node);
        }
    }
}
