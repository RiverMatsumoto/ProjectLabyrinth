using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Core
{
    [CreateAssetMenu(fileName = "GameData", menuName = "GameData/GameData")]
    public class GameData : SerializedScriptableObject
    {
        public int currentFloor;
        public bool isInBattle;
        public bool permitOpenPlayerMenu;
        public bool isInPlayerMenu;
        public bool permitPlayerMove;
        public bool playerIsMoving;
        public bool isActionable { get; private set; }

        public void EnableActionability() => isActionable = true;

        public void DisableActionability() => isActionable = false;

        [Button]
        public void SetDefaults()
        {
            currentFloor = 1;
            isInBattle = false;
            permitOpenPlayerMenu = true;
            isInPlayerMenu = false;
            permitPlayerMove = true;
            playerIsMoving = false;
            isActionable = true;
        }
    }
}
