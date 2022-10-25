using System.Collections.Generic;
using Game.Scripts.Core;
using Game.Scripts.Movement;
using Sirenix.OdinInspector;
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

        public Dictionary<string, IInteractable> interactable;

        private void Start()
        {
            interactable = new Dictionary<string, IInteractable>();
            // InitializeInteractables();
        }

        [Button]
        public void TryInteract(InputAction.CallbackContext ctx)
        {
            if (!_gameData.isActionable || !ctx.started) return;

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

        /// <summary>
        /// Initializes the interactable tiles
        /// </summary>
        // private void InitializeInteractables()
        // {
        //     foreach (var tileDict in _tileDataList.tiles)
        //     {
        //         GameTile gameTile = tileDict.Value;
        //         switch (gameTile.name)
        //         {
        //             case "Passage":
        //                 // PassageTile passageTile = new PassageTile(_playerMovement, this);
        //                 // interactable.Add(gameTile.name, passageTile);
        //                 break;
        //             case "Chest": // TODO create chest functionality (needs inventory system too)
        //                 break;
        //         }
        //     }
        // }
        //
        // // called by PlayerInput component
        // [Button]
        // public void Interact(InputAction.CallbackContext ctx)
        // {
        //     if (!ctx.started || !_gameData.isActionable) return;
        //
        //     string tileName = _playerMovement.GetTileInFrontOfPlayer().name;
        //     if (interactable.ContainsKey(tileName))
        //     {
        //         DisableActionability();
        //         interactable[tileName].Interact();
        //     }
        // }


        public void DisableActionability()
        {
            _gameData.DisableActionability();
        }

        public void EnableActionability()
        {
            _gameData.EnableActionability();
        }
    }
}