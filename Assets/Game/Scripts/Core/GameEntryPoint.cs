using UnityEngine;

namespace Game.Scripts.Core
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneChanger _sceneChanger;

        private void Start()
        {
            Application.targetFrameRate = 60;
            _sceneChanger.ChangeScene("MainMenu", false);
        }
    }
}
