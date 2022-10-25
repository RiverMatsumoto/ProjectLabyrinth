using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class TownLabyrinthExit : MonoBehaviour
    {
        [Inject] private GameData _gameData;
        
        public void EnterLabyrinth(int floor)
        {
            _gameData.currentFloor = floor;
            SceneChanger.Instance.ChangeScene("Labyrinth");
        }
    }
}
