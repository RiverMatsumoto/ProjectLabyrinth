using System;
using Game.Scripts.Core;
using Game.Scripts.Movement;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.MapSystem
{
    public class PassageInteraction : MonoBehaviour, IInteractable
    {
        [Inject] public PlayerMovement _playerMovement;
        private InteractionHandler _interactionHandler;

        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
        }

        public PassageInteraction(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        public void Interact(InteractionHandler interactionHandler)
        {
            _interactionHandler = interactionHandler;
            // screen fade and move player to the other side of the wall
            _interactionHandler.DisableActionability();
            SceneChanger.Instance.FadeScreen(MovePlayer);
        }

        [Button]
        public void MovePlayer()
        {
            Vector2Int localFwd = _playerMovement.localForward;
            Vector3 currPos = _playerMovement.transform.position;
            Vector3Int otherSide = new Vector3Int(
                Mathf.RoundToInt(currPos.x) + (localFwd.x * 2),
                Mathf.RoundToInt(currPos.y),
                Mathf.RoundToInt(currPos.z) + (localFwd.y * 2)
            );
            _playerMovement.MoveStatic(otherSide);
            _playerMovement.CheckIfFacingInteractable();
            _interactionHandler.EnableActionability();
        }
    }
}
