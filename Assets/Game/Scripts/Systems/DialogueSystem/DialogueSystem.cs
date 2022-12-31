using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Febucci.UI;
using Game.Scripts.Core;
using ModestTree;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

namespace Game.Scripts.Systems.DialogueSystem
{
    public enum DialogueType { TEXT, DECISION, EVENT }
    public class DialogueSystem : MonoBehaviour
    {
        [Inject] private SettingsData _settings;
        [Inject] private GameData _gameData;

        // Textbox visuals
        public GameObject textBox;
        public TMP_Text text;
        public Image background;
        public Image border;
        public TextAnimator textAnimator;
        public TextAnimatorPlayer textAnimatorPlayer;
        public DialogueDecisionUI dialogueDecisionUI;

        // Integer in event used for branching to different dialogues
        public ReactiveCommand<int> dialogueSectionFinishedEvent;
        private IEnumerator<string> _textboxIter;
        private DialogueNode _currentDialogue;
        private IDisposable _delayedIsTextboxEnabledObservable;
        private bool _delayedIsTextboxEnabled;

        private void Awake()
        {
            dialogueSectionFinishedEvent = new ReactiveCommand<int>();
        }

        private void Start()
        {
            textBox.SetActive(false);
            ApplySettings();
            _delayedIsTextboxEnabledObservable = Observable.EveryUpdate().Delay(TimeSpan.FromMilliseconds(50)).Subscribe(_ =>
            {
                _delayedIsTextboxEnabled = textBox.activeInHierarchy;
            });

        }

        [Button]
        public void OpenDialogue(DialogueNode node)
        {
            // store the dialogue to loop through and go to the next dialogue
            _currentDialogue = node;
            _textboxIter = node.textboxes.GetEnumerator();
            _textboxIter.Reset();
            EventSystem.current.SetSelectedGameObject(textBox);
            _gameData.DisableMovement();
            if (node.dialogueType == DialogueType.DECISION)
                textAnimatorPlayer.onTextShowed.AddListener(OnDecisionTextboxFinished);
            StartCoroutine(AnimateOpenDialogue());
        }

        private IEnumerator AnimateOpenDialogue()
        {
            const float ANIM_TIME = 0.1f;
            textBox.SetActive(true);
            textBox.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            textBox.transform.DOScale(Vector3.one, ANIM_TIME);
            yield return new WaitForSeconds(ANIM_TIME);
            NextTextBox();
        }

        public void CloseDialogue(int branch = 0)
        {
            // cast event that the dialogue closed, nodes will listen for this and go to the next dialogue/event
            textBox.SetActive(false);
            text.text = string.Empty;
            _textboxIter.Dispose();
            _gameData.EnableMovement();
            dialogueSectionFinishedEvent.Execute(branch);
        }

        private void OnDecisionTextboxFinished()
        {
            if (dialogueDecisionUI.buttons.Count == 0) return;
            
            textAnimatorPlayer.onTextShowed.RemoveAllListeners();
            EventSystem.current.SetSelectedGameObject(dialogueDecisionUI.buttons[0].gameObject);
        }

        public void OnInteract(InputAction.CallbackContext ctx) // Called by player input
        {
            UnityEngine.Debug.Log("Tried to interact");
            if (_delayedIsTextboxEnabled && ctx.started)
                InteractWithTextBox();
        }

        public void OnClick(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;
            if (textBox.activeInHierarchy)
                InteractWithTextBox();
        }
        
        public void InteractWithTextBox()
        {
            // if waitingForScroll, fill the textbox instantly
            // else waitingForScroll, go to the next textbox NextDialogue()
            ApplySettings();
            if (!textAnimator.allLettersShown)
            {
                textAnimator.ShowAllCharacters(true);
                if (dialogueDecisionUI.buttons.Count != 0)
                    dialogueDecisionUI.buttons[1].GetComponent<Button>().Select();
            }
            else if (_currentDialogue.dialogueType != DialogueType.DECISION)
            {
                NextTextBox();
            }
        }

        public void NextTextBox()
        {
            // scroll through the next textbox, do a settings check for scroll speed here
            if (_textboxIter.MoveNext())
                switch (_currentDialogue.dialogueType)
                {
                    case DialogueType.TEXT:
                        NextTextBoxTextNode();
                        break;
                    case DialogueType.DECISION:
                        NextTextBoxDecisionNode();
                        break;
                    case DialogueType.EVENT:
                        NextTextBoxEventNode();
                        break;
                }
            else
            {
                CloseDialogue();
            }
        }

        private void NextTextBoxTextNode()
        {
            text.text = _textboxIter.Current;
        }
        
        private void NextTextBoxEventNode()
        {
            NextTextBoxTextNode();
        }

        private void NextTextBoxDecisionNode()
        {
            // Display prompt
            dialogueDecisionUI.DisplayDecision(_currentDialogue.textboxes);
        }
        
        public void ChoseOptionOnDecisionNode(int option)
        {
            CloseDialogue(option);
        }

        private void ApplySettings()
        {
            switch (_settings.textScrollSpeed)
            {
                case SettingsData.TextScrollSpeed.SLOW:
                    SetScrollSpeed(0.02f);
                    textAnimatorPlayer.useTypeWriter = true;
                    break;
                case SettingsData.TextScrollSpeed.MEDIUM:
                    SetScrollSpeed(0.01f);
                    textAnimatorPlayer.useTypeWriter = true;
                    break;
                case SettingsData.TextScrollSpeed.FAST:
                    SetScrollSpeed(0.005f);
                    textAnimatorPlayer.useTypeWriter = true;
                    break;
                case SettingsData.TextScrollSpeed.INSTANT:
                    textAnimatorPlayer.useTypeWriter = false;
                    break;
            }
        }

        private void SetScrollSpeed(float speed)
        {
            textAnimatorPlayer.waitLong = speed;
            textAnimatorPlayer.waitMiddle = speed;
            textAnimatorPlayer.waitForNormalChars = speed;
        }
        


#if UNITY_EDITOR
        [Button]
        public void TestDialogue(string text)
        {
        }

#endif
    }
}