using System.Collections.Generic;
using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.SkillCommands;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueEventNode : DialogueNode
    {
        [SerializeField] private ICommand _command;

        public DialogueEventNode(ICommand command, DialogueSystem ds, IList<string> textboxes = null) 
            : base(ds, DialogueType.EVENT, textboxes)
        {
            _command = command;
            this.Textboxes = textboxes;
        }
        
        public override void TryNextDialogue(int branch = 0)
        {
            _command.Execute();
            Subscription.Dispose();
            if (Branches.Count <= 0) return;
            
            Branches[branch].OpenDialogue();
        }
        
        public class Factory : PlaceholderFactory<IList<string>, ICommand, DialogueEventNode> { }
    }
}
