using System.Collections;
using Game.Scripts.Core;
using Game.Scripts.Systems.BattleSystem;
using Game.Scripts.Systems.Data;
using Michsky.MUIP;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.PlayerMenu
{
    public class PlayerMenu : MonoBehaviour
    {
        [Inject] private GameData _gameData;
        [Inject] private SettingsData _settingsData;
        [SerializeField] public WindowManager windowManager;
        [SerializeField] private Image background;
        public bool inPlayerMenu;
        public bool canOpenMenu = true;

        private void Start()
        {
            CloseMenu();
        }

        public void OnToggleMenu()
        {
            if (inPlayerMenu) CloseMenu();
            else if (canOpenMenu) OpenMenu();
        }


        // TODO Implement animations instead of simply enabling
        public void OpenMenu()
        {
            UnityEngine.Debug.Log("Got Here");
            windowManager.OpenWindow("MainPlayerMenu");
            background.gameObject.SetActive(true);
            inPlayerMenu = true;
            _gameData.DisableMovement();
        }

        public void CloseMenu()
        {
            // windowManager.gameObject.SetActive(false);
            windowManager.OpenWindow("Closed");
            StartCoroutine(DelayDisableBackground());
            inPlayerMenu = false;
            _gameData.EnableMovement();
        }
        
        private IEnumerator DelayDisableBackground()
        {
            yield return new WaitForSeconds(0.2f);
            background.gameObject.SetActive(false);
        }

        public void SetFpsVisibility(bool visibility)
        {
            _settingsData.showFps.Value = visibility;
        }
    }
}