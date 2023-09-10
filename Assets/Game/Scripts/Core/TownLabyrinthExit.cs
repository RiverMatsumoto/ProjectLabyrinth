using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class TownLabyrinthExit : MonoBehaviour
    {
        [Inject] private GameData _gameData;
        [Inject] private SceneChanger _sceneChanger;
        
        public void EnterLabyrinth(int floor)
        {
            _gameData.EnableMovement();
            _gameData.currentFloor = floor;
            _sceneChanger.ChangeScene("Labyrinth");
        }
    }
}
