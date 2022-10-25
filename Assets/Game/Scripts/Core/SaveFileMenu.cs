using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class SaveFileMenu : MonoBehaviour
    {
        
        [Button]
        public void DebugLoadSaveFile()
        {
            SceneChanger.Instance.ChangeScene("Town", false);
        }
    }
}
