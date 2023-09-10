using System.Collections.Generic;
using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.DialogueSystem;
using Game.Scripts.Systems.SkillCommands;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.Scripts.Installers
{
    public class DialogueInstaller : MonoInstaller
    {
        [SerializeField] private DialogueSystem _dialogueSystem;
        
        public override void InstallBindings()
        {
            _dialogueSystem = FindObjectOfType<DialogueSystem>();
            
            // install all the dialogues with their dependencies
            Container.Bind<DialogueSystem>().FromInstance(_dialogueSystem).AsSingle();
            Container.BindFactory<DialogueBuilder, DialogueBuilder.Factory>().AsTransient().NonLazy();
            Container.BindFactory<IList<string>, DialogueTextNode, DialogueTextNode.Factory>().AsSingle().NonLazy();
            Container.BindFactory<IList<string>, DialogueDecisionNode, DialogueDecisionNode.Factory>().AsSingle().NonLazy();
            Container.BindFactory<IList<string>, ICommand, DialogueEventNode, DialogueEventNode.Factory>().AsSingle().NonLazy();
            
            // Initialize factory parameters
            Container.Bind<DialogueType>().FromInstance(DialogueType.TEXT).WhenInjectedInto<DialogueTextNode>();
            Container.Bind<DialogueType>().FromInstance(DialogueType.DECISION).WhenInjectedInto<DialogueDecisionNode>();
            Container.Bind<DialogueType>().FromInstance(DialogueType.EVENT).WhenInjectedInto<DialogueEventNode>();
        }
        
        
    }
}