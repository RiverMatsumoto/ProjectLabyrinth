using Game.Scripts.Core;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Game.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [Button]
        public void QuitGame()
        {
            Application.Quit();
        }

        [Button]
        public void DebugStart()
        {
            SceneChanger.Instance.ChangeScene("Town");
        }
    }
} 
