using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    public abstract class Dialogue : MonoBehaviour
    {
        [Inject] protected DialogueBuilder.Factory dialogueBuilderFactory;
        protected DialogueBuilder dialogueBuilder;

        public void OpenDialogue() => dialogueBuilder.OpenDialogue();

        protected abstract void BuildDialogue();

    }
}
