using System.Collections.Generic;
using Game.Scripts.Systems.SkillCommands;
using Game.Scripts.Systems.SkillCommands.Factories;
using Zenject;
using UniRx;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueBuilder
    {
        private SkillCommandProvider _skillCommandProvider;
        private DialogueNode _start;
        private DialogueNode _current;
        [Inject] private DialogueTextNode.Factory _dialogueTextNodeFactory;
        [Inject] private DialogueDecisionNode.Factory _dialogueDecisionNodeFactory;
        [Inject] private DialogueEventNode.Factory _dialogueEventNodeFactory;

        public void InitializeDialogue(IList<string> textboxes)
        {
            _start = _dialogueTextNodeFactory.Create(textboxes);
            _current = _start;
        }

        public void OpenDialogue() => _start.OpenDialogue();

        private void AppendNode(DialogueType dialogueType, IList<string> textboxes, ISkillCommand command = null)
        {
            DialogueNode toAppend = null;
            switch (dialogueType)
            {
                case DialogueType.TEXT:
                    toAppend = _dialogueTextNodeFactory.Create(textboxes);
                    break;
                case DialogueType.DECISION:
                    toAppend = _dialogueDecisionNodeFactory.Create(textboxes);
                    break;
                case DialogueType.EVENT:
                    toAppend = _dialogueEventNodeFactory.Create(textboxes, command);
                    break;
            }
            _current.AddBranch(toAppend);
        }

        public void AppendTextNode(IList<string> textboxes) => AppendNode(DialogueType.TEXT, textboxes);
        public void AppendDecisionNode(IList<string> textboxes) => AppendNode(DialogueType.DECISION, textboxes);
        public void AppendEventNode(IList<string> textboxes, ISkillCommand command) => AppendNode(DialogueType.EVENT, textboxes, command);

        public bool TraverseBranchesFromStart(IList<int> path)
        {
            if (!ValidatePathIndices(path)) return false;
            
            DialogueNode temp = _start;
            foreach (int index in path)
                temp = temp.branches[index];

            _current = temp;
            UnityEngine.Debug.Log($"Current: {_current.ToString()}");
            UnityEngine.Debug.Log($"Start: {_start.ToString()}");
            return true;
        }

        private bool ValidatePathIndices(IList<int> path)
        {
            foreach (int index in path)
                if (index > 4) return false;
            return true;
        }

        public class Factory : PlaceholderFactory<DialogueBuilder> {}
    }
}