using Michsky.MUIP;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] 
        private WindowManager _windowManager;

        public GameObject playerMenu;
        public GameObject otherUI;
        public bool InPlayerMenu;
        public bool canOpenPlayerMenu;

        private void Start()
        {
            InPlayerMenu = false;
            canOpenPlayerMenu = true;
        }

        [Button]
        public void TogglePlayerMenu(InputAction.CallbackContext ctx)
        {
            // Make the first window always the playermenu
            if (!ctx.started) return;
            TogglePlayerMenu();
        }

        public void TogglePlayerMenu()
        {
            if (InPlayerMenu)
            {
                InPlayerMenu = false;
                CloseMenu();
            }
            else if (canOpenPlayerMenu)
            {
                InPlayerMenu = true;
                OpenMenu();
            }
            
        }
        
        public void OpenMenu()
        {
            playerMenu.SetActive(true);
            otherUI.SetActive(false);
            // background.gameObject.SetActive(true);
            InPlayerMenu = true;
        }

        public void CloseMenu()
        {
            playerMenu.SetActive(false);
            otherUI.SetActive(true);
            // background.gameObject.SetActive(false);
            InPlayerMenu = false;
        }
    }
}
