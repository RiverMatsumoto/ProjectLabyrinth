using Michsky.MUIP;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectLabyrinth.Game.UI.PlayerMenu
{
    public class PlayerMenu : MonoBehaviour
    {
        [SerializeField] private WindowManager windowManager;
        [SerializeField] private Image background;
        public bool inPlayerMenu;
        public bool canOpenMenu = true;

        private void Start()
        {
            CloseMenu();
        }

        public void ToggleMenu()
        {
            if (inPlayerMenu) CloseMenu();
            else if (canOpenMenu) OpenMenu();
        }


        public void OpenMenu()
        {
            windowManager.gameObject.SetActive(true);
            background.gameObject.SetActive(true);
            inPlayerMenu = true;
        }

        public void CloseMenu()
        {
            windowManager.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
            inPlayerMenu = false;
        }
    }
}