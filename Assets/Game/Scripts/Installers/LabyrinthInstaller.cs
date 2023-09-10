using Game.Scripts.Core;
using Game.Scripts.Signals;
using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.MapSystem;
using Game.Scripts.Systems.Movement;
using Game.Signals;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Installers
{
    public class LabyrinthInstaller : MonoInstaller
    {
        [SerializeField] private InteractionHandler interactionHandler;
        [SerializeField] private GameObject mapSystem;
        [SerializeField] private GameObject playerMovement;
        [SerializeField] private GameObject encounterSystem;
    
        public override void InstallBindings()
        {
            
            // Container.Bind<MapSystem>().FromComponentInNewPrefab(mapSystem).AsSingle().NonLazy();
            //
            // Container.Bind<PlayerMovement>().FromComponentInNewPrefab(playerMovement).AsSingle().NonLazy();
            // Container.Bind<EncounterSystem>().FromComponentInNewPrefab(encounterSystem).AsSingle().NonLazy();
            
            Container.Bind<InteractionHandler>().FromInstance(interactionHandler).AsSingle();
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
    }
}