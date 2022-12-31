using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    [RequireComponent(typeof(EventSystem))]
    public class DefaultSelectableFix : MonoBehaviour
    {
        private EventSystem _eventSystem;
        [SerializeField] private PlayerInput _controls;
        
        [Button]
        public void FindSelectable()
        {
            UnityEngine.Debug.Log("Find selectable");
            GameObject[] selectables = GameObject.FindGameObjectsWithTag("DefaultSelected");
            List<Button> defaultSelectedButtons = new List<Button>();
            foreach (var selectable in selectables)
            {
                if (selectable.gameObject.activeInHierarchy)
                    defaultSelectedButtons.Add(selectable.GetComponent<Button>());
            }

            foreach (var button in defaultSelectedButtons)
            {
                if (button)
                {
                    button.Select();
                }
            }
        }

        private void Start()
        {
            _eventSystem = GetComponent<EventSystem>();
            _controls = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            GameObject currentSelected = _eventSystem.currentSelectedGameObject;

            if (_controls.actions["Navigate"].IsPressed() && currentSelected == null)
                FindSelectable();
            else if (currentSelected != null)
                if (!currentSelected.activeInHierarchy)
                    FindSelectable();
        }
    }
}