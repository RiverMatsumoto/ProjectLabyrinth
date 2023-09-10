using System.Collections.Generic;
using Game.Scripts.Core;
using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.Data;
using Game.Scripts.Systems.Data.Inventory;
using Game.Scripts.Systems.DialogueSystem;
using Game.Scripts.Systems.MapSystem;
using Game.Scripts.Systems.Movement;
using Game.UI.MainMenu;
using Game.UI.PlayerMenu;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject battleSystem;
        [SerializeField] private GameObject dialogueSystem;
        [SerializeField] private GameObject sceneChanger;
        [SerializeField] private GameObject mapSystem;
        [SerializeField] private GameObject encounterSystem;
        [SerializeField] private GameObject playerMovement;
        [SerializeField] private GameObject playerMenu;
        [SerializeField] private GameObject inventory;
        [SerializeField] private GameObject battleEntityPartyUI;

        public override void InstallBindings()
        {
            Application.targetFrameRate = 120;

            SignalBusInstaller.Install(Container);
            Container.Bind<GameData>().FromScriptableObjectResource("ScriptableObjects/GameData").AsSingle().NonLazy();
            Container.Bind<SettingsData>().FromScriptableObjectResource("ScriptableObjects/SettingsData").AsSingle()
                .NonLazy();
            Container.Bind<PlayerMenu>().FromComponentInNewPrefab(playerMenu).AsSingle().NonLazy();
            Container.Bind<Inventory>().AsSingle().NonLazy();
            Container.Bind<SceneChanger>().FromComponentInNewPrefab(sceneChanger).AsSingle().NonLazy();

            Container.Bind<BattleSystem>().FromComponentInNewPrefab(battleSystem).AsSingle().NonLazy();
            
            Container.Bind<MapSystem>().FromComponentInNewPrefab(mapSystem).AsSingle().NonLazy();
            Container.Bind<TileDataList>().FromScriptableObjectResource("ScriptableObjects/Tiles/TileDataList")
                .AsSingle().NonLazy();
            Container.Bind<EncounterData>().FromScriptableObjectResource("ScriptableObjects/EncounterData")
                .AsSingle().NonLazy();

            Container.Bind<PlayerMovement>().FromComponentInNewPrefab(playerMovement).AsSingle().NonLazy();
            Container.Bind<EncounterSystem>().FromComponentInNewPrefab(encounterSystem).AsSingle().NonLazy();

            Container.Bind<BattleEvents>().FromScriptableObjectResource("ScriptableObjects/BattleEvents").AsSingle();
            Container.Bind<BattleEntityPartyUI>().FromComponentInNewPrefab(battleEntityPartyUI).AsSingle();
            Container.BindFactory<BattleEntity, BattleEntityUI, BattleEntityUI.Factory>().AsSingle();

            InstallDialogueSystem();
            InstallUI();
        }

        private void InstallDialogueSystem()
        {
            Container.Bind<DialogueSystem>().FromComponentInNewPrefab(dialogueSystem).AsSingle().NonLazy();
            Container.BindFactory<DialogueBuilder, DialogueBuilder.Factory>().AsTransient().NonLazy();
            Container.BindFactory<IList<string>, DialogueTextNode, DialogueTextNode.Factory>().AsSingle().NonLazy();
            Container.BindFactory<IList<string>, DialogueDecisionNode, DialogueDecisionNode.Factory>().AsSingle()
                .NonLazy();
            Container.BindFactory<IList<string>, ICommand, DialogueEventNode, DialogueEventNode.Factory>()
                .AsSingle().NonLazy();

            // Initialize factory parameters
            Container.Bind<DialogueType>().FromInstance(DialogueType.TEXT).WhenInjectedInto<DialogueTextNode>();
            Container.Bind<DialogueType>().FromInstance(DialogueType.DECISION).WhenInjectedInto<DialogueDecisionNode>();
            Container.Bind<DialogueType>().FromInstance(DialogueType.EVENT).WhenInjectedInto<DialogueEventNode>();
        }

        private void InstallUI()
        {
            Container.BindInterfacesTo<ScaleAnimation>().AsSingle();
        }
    }
}