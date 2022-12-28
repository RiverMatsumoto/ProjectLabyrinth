using System;
using Game.Scripts.Installers;
using Game.Scripts.Systems.DialogueSystem;
using Game.Scripts.Systems.SkillCommands.Factories;
using UnityEngine;
using Zenject;

namespace Game.Debug
{
    public class TestScriptableObjectInject : MonoBehaviour
    {
        public StoryEventData storyEvent;

        [Inject] private SkillCommandProvider _skillCommandProvider;

        private void Start()
        {
            storyEvent.skillCommandProvider = _skillCommandProvider;
        }
    }
}
