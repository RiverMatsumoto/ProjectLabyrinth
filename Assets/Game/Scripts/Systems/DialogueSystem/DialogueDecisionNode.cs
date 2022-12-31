
using System.Collections.Generic;
using Game.Scripts.Movement;
using Michsky.MUIP;
using Sirenix.OdinInspector;
using UniRx;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueDecisionNode : DialogueNode
    {

        public DialogueDecisionNode(DialogueSystem dialogueSystem, IList<string> textboxes = null) 
            : base(dialogueSystem, DialogueType.DECISION, textboxes)
        {
            this.textboxes = textboxes;
        }


        public class Factory : PlaceholderFactory<IList<string>, DialogueDecisionNode> { }
    }
}
