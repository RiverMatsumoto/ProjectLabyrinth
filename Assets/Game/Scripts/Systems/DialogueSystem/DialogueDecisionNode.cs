using System.Collections.Generic;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueDecisionNode : DialogueNode
    {

        public DialogueDecisionNode(DialogueSystem dialogueSystem, IList<string> textboxes = null) 
            : base(dialogueSystem, DialogueType.DECISION, textboxes)
        {
            this.Textboxes = textboxes;
        }


        public class Factory : PlaceholderFactory<IList<string>, DialogueDecisionNode> { }
    }
}
