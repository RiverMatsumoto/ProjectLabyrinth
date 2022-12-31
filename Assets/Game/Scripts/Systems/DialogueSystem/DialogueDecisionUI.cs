using System.Collections.Generic;
using Michsky.MUIP;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace Game.Scripts.Systems.DialogueSystem
{
    public class DialogueDecisionUI : MonoBehaviour
    {
        public const int MAX_OPTIONS = 4;
        public GameObject buttonPrefab;
        public Navigation customNav = new Navigation();
        public List<Button> buttons;
        
        [Inject] private DialogueSystem _dialogueSystem;

        public void DisplayDecision(IList<string> decisions)
        {
            string prompt = decisions[0];
            _dialogueSystem.text.text = prompt;
            decisions.RemoveAt(0);
            for (int i = 0; i < decisions.Count; i++)
            {
                GameObject button = Instantiate(buttonPrefab, transform);
                buttons.Add(button.GetComponent<Button>());
                buttons[i].GetComponentInChildren<ButtonManager>().SetText(decisions[i]);
                StoreCallbackParams(i);
            }
        }

        public void StoreCallbackParams(int buttonIndex)
        {
            buttons[buttonIndex].onClick.AddListener(() => SelectOption(buttonIndex));
        }

        public void SelectOption(int option)
        {
            DeleteButtons();
            _dialogueSystem.ChoseOptionOnDecisionNode(option);
        }

        // private void AssignUINavigation()
        // {
        //     for (int i = 0; i < buttons.Count; i++)
        //     {
        //         if (i == 0)
        //         {
        //             buttons[i].selectOnUp = buttons[buttons.Count - 1].gameObject;
        //             buttons[i].selectOnDown = buttons[i + 1].gameObject;
        //         }
        //         else if (i == buttons.Count - 1)
        //         {
        //             buttons[i].selectOnUp = buttons[i - 1].gameObject;
        //             buttons[i].selectOnDown = buttons[0].gameObject;
        //         }
        //         else
        //         {
        //             buttons[i].selectOnDown = buttons[i + 1].gameObject;
        //             buttons[i].selectOnUp = buttons[i - 1].gameObject;
        //         }
        //     }
        // }

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
