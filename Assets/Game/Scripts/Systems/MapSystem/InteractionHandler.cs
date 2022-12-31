using System;
using System.Collections.Generic;
using Game.Scripts.Core;
using Game.Scripts.Movement;
using Game.Scripts.Systems.Movement;
using GitHub.Unity;
using Michsky.MUIP;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Scripts.Systems.MapSystem
{
    public class InteractionHandler : MonoBehaviour
    {
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private TileDataList _tileDataList;
        [Inject] private GameData _gameData;
        private IObservable<bool> actionabilityHistory;
        private bool _delayedPermitPlayerActionability;

        [Button]
        public void OnInteract(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;
            if (!_gameData.permitMovingPlayer || !_delayedPermitPlayerActionability) return;
            UnityEngine.Debug.Log("Interacted");

            // Check whether the tile in front is interactable
            RaycastHit hit;
            Vector3 playerPosition = _playerMovement.transform.position;
            Vector3 playerForward = _playerMovement.transform.forward;
            if (Physics.Raycast(playerPosition, playerForward, out hit, 1))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(this);
                }
            }
        }

        private void Start()
        {
            actionabilityHistory = Observable.Create<bool>(
                (observer) =>
                {
                    IDisposable emitter = Observable
                        .EveryUpdate()
                        .Subscribe((_) =>
                        {
                            observer.OnNext(_gameData.permitMovingPlayer);
                        });

                    return emitter;
                });

            actionabilityHistory.Delay(TimeSpan.FromMilliseconds(20))
                .Subscribe(next => _delayedPermitPlayerActionability = next);
        }
    }
}