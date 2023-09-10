using Game.Scripts.Systems.Commands;
using Game.Scripts.Systems.Movement;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.GameDebug
{
    public class DynamicInject : MonoBehaviour
    {
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private ICommand _command;

        [Button]
        public void LogPlayer()
        {
            UnityEngine.Debug.Log($"Player: {_playerMovement.name}");
            UnityEngine.Debug.Log($"Command: {_command.ToString()}");
        }
    }
}
