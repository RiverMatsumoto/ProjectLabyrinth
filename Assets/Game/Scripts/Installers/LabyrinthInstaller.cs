using Game.Scripts.Core;
using Game.Scripts.Movement;
using Game.Scripts.Signals;
using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.MapSystem;
using Game.Signals;
using ProjectLabyrinth.Game.UI.PlayerMenu;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class LabyrinthInstaller : MonoInstaller
    {
        [SerializeField] private MapSystem _mapSystem;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private TileDataList _tileDataList;
        [SerializeField] private InteractionHandler _interactionHandler;
        [SerializeField] private EncounterSystem _encounterSystem;
        
        //Tiles
        [SerializeField] private GameObject passageTile;
    
        public override void InstallBindings()
        {
            FindSystemsInHierarchy();
            Container.Bind<MapSystem>().FromInstance(_mapSystem).AsSingle();
            Container.Bind<PlayerMovement>().FromInstance(playerMovement).AsSingle();
            Container.Bind<TileDataList>().FromInstance(_tileDataList).AsSingle();
            Container.Bind<InteractionHandler>().FromInstance(_interactionHandler).AsSingle();
            Container.Bind<EncounterSystem>().FromInstance(_encounterSystem).AsSingle();
            InstallSignals();
            InstallTiles();
            
            
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<PlayerMovedStartSignal>().OptionalSubscriber();
            Container.DeclareSignal<PlayerMovedEndSignal>().OptionalSubscriber();
            Container.DeclareSignal<EncounteredInteractableSignal>().OptionalSubscriber();
            Container.DeclareSignal<StepTakenSignal>().OptionalSubscriber();
        }
        
        private void InstallTiles()
        {
            // Container.Bind<PassageTile>().FromComponentInNewPrefab(passageTile).AsSingle();
        }

        private void FindSystemsInHierarchy()
        {
            _encounterSystem = FindObjectOfType<EncounterSystem>();
            playerMovement = FindObjectOfType<PlayerMovement>();
            _mapSystem = FindObjectOfType<MapSystem>();
        }
    }
}