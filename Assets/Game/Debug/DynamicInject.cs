using Game.Scripts.Movement;
using Game.Scripts.Systems.SkillCommands;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Debug
{
    public class DynamicInject : MonoBehaviour
    {
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private ISkillCommand command;

        [Button]
        public void LogPlayer()
        {
            UnityEngine.Debug.Log($"Player: {_playerMovement.name}");
            UnityEngine.Debug.Log($"Command: {command.ToString()}");
        }
    }
}
