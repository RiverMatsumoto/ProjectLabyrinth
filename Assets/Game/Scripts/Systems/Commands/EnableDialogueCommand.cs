using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.Commands
{
    public class EnableDialogueCommand : ICommand
    {
        private readonly BoxCollider _dialogueTrigger;
        
        public EnableDialogueCommand(BoxCollider dialogueTrigger)
        {
            _dialogueTrigger = dialogueTrigger;
        }
        public void Execute()
        {
            _dialogueTrigger.enabled = true;
        }

        public class Factory : PlaceholderFactory<BoxCollider, EnableDialogueCommand> { }
    }
}
