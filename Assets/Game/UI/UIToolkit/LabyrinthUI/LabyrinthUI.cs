using System;
using Game.Scripts.Movement;
using Game.Scripts.Systems.MapSystem;
using Game.Scripts.Systems.Movement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Game.UI.UIToolkit.LabyrinthUI
{
    [RequireComponent(typeof(UIDocument))]
    public class LabyrinthUI : MonoBehaviour
    {
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private InteractionHandler _interactionHandler;
        private VisualElement root;
        private Label interactLabel;

        private void Start()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            interactLabel = root.Q<Label>("Interact");
            interactLabel.visible = false;
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        [Button]
        public void ShowInteractLabel(bool isInteractable)
        {
            interactLabel.visible = isInteractable;
        }
    }
}
