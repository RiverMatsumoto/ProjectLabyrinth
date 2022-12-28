using System;
using System.Collections.Generic;
using Michsky.MUIP;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueDecisionUI : MonoBehaviour
    {
        public const int MAX_OPTIONS = 4;
        public GameObject buttonPrefab;
        public List<ButtonManager> buttons;
        [Inject] private DialogueSystem _dialogueSystem;

        public void DisplayDecision(IList<string> decisions)
        {
            string prompt = decisions[0];
            _dialogueSystem.text.text = prompt;
            decisions.RemoveAt(0);
            for (int i = 0; i < decisions.Count; i++)
            {
                GameObject button = Instantiate(buttonPrefab, transform);
                buttons.Add(button.GetComponent<ButtonManager>());
                buttons[i].SetText(decisions[i]);
                
                if (i == 0) buttons[i]?.onClick.AddListener(Option1);
                else if (i == 1) buttons[i]?.onClick.AddListener(Option2);
                else if (i == 2) buttons[i]?.onClick.AddListener(Option3);
                else if (i == 3) buttons[i]?.onClick.AddListener(Option4);
                else if (i == 4) buttons[i]?.onClick.AddListener(Option5);
            }
            
            AssignUINavigation();
        }

        public void Option1()
        {
            DeleteButtons();
            _dialogueSystem.ChoseOptionOnDecisionNode(0);
        }
        public void Option2()
        {
            DeleteButtons();
            _dialogueSystem.ChoseOptionOnDecisionNode(0);
        }
        public void Option3()
        {
            DeleteButtons();
            _dialogueSystem.ChoseOptionOnDecisionNode(0);
        }
        public void Option4()
        {
            DeleteButtons();
            _dialogueSystem.ChoseOptionOnDecisionNode(0);
        }
        public void Option5()
        {
            DeleteButtons();
            _dialogueSystem.ChoseOptionOnDecisionNode(0);
        }

        private void AssignUINavigation()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (i == 0)
                {
                    buttons[i].selectOnUp = buttons[buttons.Count - 1].gameObject;
                    buttons[i].selectOnDown = buttons[i + 1].gameObject;
                }
                else if (i == buttons.Count - 1)
                {
                    buttons[i].selectOnUp = buttons[i - 1].gameObject;
                    buttons[i].selectOnDown = buttons[0].gameObject;
                }
                else
                {
                    buttons[i].selectOnDown = buttons[i + 1].gameObject;
                    buttons[i].selectOnUp = buttons[i - 1].gameObject;
                }
            }
        }

        private void DeleteButtons()
        {
            foreach (var button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }
    }
}
