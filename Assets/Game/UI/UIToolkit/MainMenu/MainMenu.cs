using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProjectLabyrinth
{
    public class MainMenu : MonoBehaviour
    {
        private Button continueGame;
        private Button newGame;
        private Button settings;
        private Button quit;
        private VisualElement root;

        
        private void OnEnable()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            continueGame = root.Q<Button>("ContinueGameButton");
            newGame = root.Q<Button>("NewGameButton");
            settings = root.Q<Button>("SettingsButton");
            quit = root.Q<Button>("QuitButton");

            continueGame.clicked += OpenSaveFileMenu;
            newGame.clicked += OpenSaveFileMenu;
            settings.clicked += OpenSettingsMenu;
            quit.clicked += Quit;
        }

        private void OnDisable()
        {
            continueGame.clicked -= OpenSaveFileMenu;
            newGame.clicked -= OpenSaveFileMenu;
            settings.clicked -= OpenSettingsMenu;
            quit.clicked -= Quit;
        }

        public void OpenSaveFileMenu()
        {
            Debug.Log("Opening savefile menu");
        }

        public void OpenSettingsMenu()
        {
            Debug.Log("Opening settings menu");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
