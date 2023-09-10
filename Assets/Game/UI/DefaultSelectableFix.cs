using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(EventSystem))]
    public class DefaultSelectableFix : MonoBehaviour
    {
        [SerializeField] private InputActionReference navigate;
        [ShowInInspector] private GameObject _lastSelected;

        private void OnEnable()
        {
            navigate.action.performed += OnPerformed;
        }

        private void OnDisable()
        {
            navigate.action.performed -= OnPerformed;
        }

        private void OnPerformed(InputAction.CallbackContext ctx)
        {
            if (ShouldTryToSelect())
                IterateAndSelectGameObject();
            else
                CacheCurrentSelected();
        }
        
        private bool ShouldTryToSelect()
        {
            GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
            if (currentSelected != null)
                if (currentSelected.GetComponent<Selectable>() != null)
                    return !currentSelected.activeInHierarchy ||
                           !currentSelected.GetComponent<Selectable>().IsInteractable();
            return false;
        }

        private void IterateAndSelectGameObject()
        {
            if (_lastSelected != null)
                if (CanSelect(_lastSelected.GetComponent<Selectable>()))
                    EventSystem.current.SetSelectedGameObject(_lastSelected.gameObject);

            foreach (Selectable selectable in FindObjectsOfType<Selectable>())
            {
                if (CanSelect(selectable))
                {
                    EventSystem.current.SetSelectedGameObject(selectable.gameObject);
                }
            }
            
        }

        private bool CanSelect(Selectable selectable)
        {
            return selectable.IsInteractable() && selectable.isActiveAndEnabled;
        }

        private void CacheCurrentSelected()
        {
            _lastSelected = EventSystem.current.currentSelectedGameObject;
        }
    }
}