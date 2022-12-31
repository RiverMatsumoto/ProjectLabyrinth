using System.Collections.Generic;
using Game.Scripts.Systems.SkillCommands;
using Mono.CompilerServices.SymbolWriter;
using UnityEngine;
using Zenject;
using System;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueEventNode : DialogueNode
    {
        [SerializeField] private ISkillCommand _command;

        public DialogueEventNode(ISkillCommand command, DialogueSystem ds, IList<string> textboxes = null) 
            : base(ds, DialogueType.EVENT, textboxes)
        {
            _command = command;
            this.textboxes = textboxes;
        }
        
        public override void TryNextDialogue(int branch = 0)
        {
            _command.Execute();
            subscription.Dispose();
            if (branches.Count <= 0) return;
            
            branches[branch].OpenDialogue();
        }
        
        public class Factory : PlaceholderFactory<IList<string>, ISkillCommand, DialogueEventNode> { }
    }
}
