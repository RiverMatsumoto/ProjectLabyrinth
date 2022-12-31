using Game.Scripts.Core;
using Game.Scripts.Movement;
using Game.Scripts.Systems.Movement;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Systems.MapSystem
{
    public class PassageInteraction : MonoBehaviour, IInteractable
    {
        [ShowInInspector, Inject] private PlayerMovement _playerMovement;
        [Inject] private GameData _gameData;

        public PassageInteraction(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        public void Interact(InteractionHandler interactionHandler)
        {
            // screen fade and move player to the other side of the wall
            _gameData.DisableMovement();
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
        }
    }
}
