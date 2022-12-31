using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;
using UnityEditor;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueTextNode : DialogueNode
    {
        public DialogueTextNode(DialogueSystem dialogueSystem, IList<string> textboxes = null) 
            : base(dialogueSystem, DialogueType.TEXT, textboxes)
        {
            this.textboxes = textboxes;
            _dialogueSystem = dialogueSystem;
        }
        
        public class Factory : PlaceholderFactory<IList<string>, DialogueTextNode> { }
    }
}
