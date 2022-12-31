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

        public bool permitMovingPlayer { get; private set; }
        public void EnableMovement() => permitMovingPlayer = true;
        public void DisableMovement() => permitMovingPlayer = false;
        public bool permitInteracting { get; private set; }
        public bool EnableInteracting => permitInteracting = true;
        public bool DisableInteracting => permitInteracting = false;
        

        [Button]
        public void SetDefaults()
        {
            currentFloor = 1;
            isInBattle = false;
            permitMovingPlayer = true;
        }
    }
}
