using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.Scripts.Core
{
    [CreateAssetMenu(fileName = "GameData", menuName = "GameData/GameData")]
    public class GameData : SerializedScriptableObject
    {
        public int currentFloor;
        public bool isInBattle;
        [OdinSerialize] public bool permitMovingPlayer { get; private set; }
        public void EnableActionability() => permitMovingPlayer = true;
        public void DisableActionability() => permitMovingPlayer = false;

        [Button]
        public void SetDefaults()
        {
            currentFloor = 1;
            isInBattle = false;
            permitMovingPlayer = true;
        }
    }
}
