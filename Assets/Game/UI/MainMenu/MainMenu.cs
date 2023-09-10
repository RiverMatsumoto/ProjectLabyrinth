using Game.Scripts.Core;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;

namespace Game.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [Inject] private SceneChanger _sceneChanger;
        
        [Button]
        public void QuitGame()
        {
            Application.Quit();
        }

        [Button]
        public void DebugStart()
        {
            _sceneChanger.ChangeScene("Town");
        }
    }
} 
