using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class SaveFileMenu : MonoBehaviour
    {
        [Inject] private SceneChanger _sceneChanger;
        
        [Button]
        public void DebugLoadSaveFile()
        {
            _sceneChanger.ChangeScene("Town", false);
        }
    }
}
