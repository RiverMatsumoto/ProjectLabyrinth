using Game.Scripts.Core;
using Game.Scripts.Movement;
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
        [SerializeField] private PlayerMenu _playerMenu;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private TileDataList _tileDataList;
        [SerializeField] private InteractionHandler _interactionHandler;
        
        //Tiles
        [SerializeField] private GameObject passageTile;
    
        public override void InstallBindings()
        {
            Container.Bind<MapSystem>().FromInstance(_mapSystem).AsSingle();
            Container.Bind<PlayerMenu>().FromInstance(_playerMenu).AsSingle();
            Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle();
            Container.Bind<GameData>().AsSingle();
            Container.Bind<TileDataList>().FromInstance(_tileDataList).AsSingle();
            Container.Bind<InteractionHandler>().FromInstance(_interactionHandler).AsSingle();
            InstallSignals();
            InstallTiles();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<PlayerMovedStartSignal>().OptionalSubscriber();
            Container.DeclareSignal<PlayerMovedEndSignal>().OptionalSubscriber();
            Container.DeclareSignal<EncounteredInteractableSignal>().OptionalSubscriber();
        }
        
        private void InstallTiles()
        {
            // Container.Bind<PassageTile>().FromComponentInNewPrefab(passageTile).AsSingle();
        }
    }
}