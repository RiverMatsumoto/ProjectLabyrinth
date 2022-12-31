using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueContainer : MonoBehaviour
    {
        public Dialogue dialogue;

        public void PlayDialogue() => dialogue.OpenDialogue();
    }
}
