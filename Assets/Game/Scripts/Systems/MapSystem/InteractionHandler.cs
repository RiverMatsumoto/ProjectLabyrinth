using System;
using Game.Scripts.Core;
using Game.Scripts.Systems.Movement;
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
        private IDisposable actionabilityHistory;
        private bool _delayedPermitPlayerActionability;

        [Button]
        public void OnInteract(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;
            if (!_delayedPermitPlayerActionability) return;

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
            actionabilityHistory = Observable.EveryUpdate().Delay(TimeSpan.FromMilliseconds(50))
                .Subscribe(_ => _delayedPermitPlayerActionability = _gameData.permitMovingPlayer);
        }
    }
}