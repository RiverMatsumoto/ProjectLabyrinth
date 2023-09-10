using System.Collections.Generic;
using Game.Scripts.Systems.Data.Inventory;
using Game.Scripts.Systems.Data.Items;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Zenject;

namespace Game.UI.PlayerMenu
{
    public class ItemsMenu : MonoBehaviour
    {
        [SerializeField] private Scrollbar scrollbar;
        [SerializeField] private GameObject itemsList;
        [SerializeField] private GameObject itemButton;
        [SerializeField] private GameObject backToMainMenuButton;
        [SerializeField] private InputActionReference navigate;
        [SerializeField] private InputActionReference escape;
        [Inject] private PlayerMenu _playerMenu;
        [Inject] private Inventory _inventory;
        public List<GameObject> itemButtons;

        private const int ITEMS_WINDOWS_INDEX = 2;

        private void Start()
        {
            Button _backToMainMenuButton = backToMainMenuButton.GetComponent<Button>();
            Navigation explicitNavigation = new Navigation();
            explicitNavigation.mode = Navigation.Mode.Explicit;
            if (itemButtons.Count > 0)
                explicitNavigation.selectOnDown = itemButtons[0].GetComponent<Selectable>();
            _backToMainMenuButton.navigation = explicitNavigation;
        }

        private void AddItemButton()
        {
            GameObject newItemButton = Instantiate(itemButton, itemsList.transform);
            itemButtons.Add(newItemButton);
            newItemButton.GetComponent<ItemButton>();
        }

        public void OnNavigate()
        {
            GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
            int currentSelectedIndex = itemButtons.IndexOf(currentSelected);
            if (currentSelectedIndex >= 0)
            {
                if (currentSelectedIndex == itemButtons.Count - 1)
                {
                    scrollbar.value = 0;
                }
                else
                {
                    int totalItems = itemButtons.Count;
                    float scrollRatio = 1 - (float) currentSelectedIndex / (float) totalItems;
                    scrollbar.value = scrollRatio;
                }
            }
        }

        private void Update()
        {
            if (navigate.action.IsPressed())
            {
                OnNavigate();
            }
        }

        public void OnEscape(InputAction.CallbackContext ctx)
        {
            if (_playerMenu.windowManager.currentWindowIndex == ITEMS_WINDOWS_INDEX)
            {
                _playerMenu.windowManager.OpenWindow("MainPlayerMenu");
            }
        }

        private void OnEnable()
        {
            escape.action.started += OnEscape;
        }
        
        private void OnDisable()
        {
            escape.action.started -= OnEscape;
        }
    }
}
