using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Core
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private GameObject rootParent;
        [SerializeField] private Animator animator;
        private bool _doneFadingIn;

        public static SceneChanger Instance
        {
            get => _instance;
        }
        private static SceneChanger _instance;


        private void Start()
        {
            DontDestroyOnLoad(rootParent);
            if (_instance != null)
            {
                UnityEngine.Debug.Log("Extra SceneChanger instance disabled/destroyed. Only a single instance is allowed");
                Destroy(rootParent);
            }
            else
            {
                _instance = this;
            }
        }

        public void AddScene(string scene)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }

        [Button]
        public void ChangeScene(string scene, bool additive = false)
        {
            StartCoroutine(FadeIn(scene, additive));
        }

        private IEnumerator FadeIn(string scene, bool additive)
        {
            _doneFadingIn = false;
            animator.SetTrigger("FadeIn");
            while (!_doneFadingIn) yield return null;

            if (additive) SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            else SceneManager.LoadScene(scene);
        }

        // Called by animation event
        public void FinishedChangingScene()
        {
            _doneFadingIn = true;
        }

        public void FadeScreen(Action callback)
        {
            StartCoroutine(FadeIn(callback));
        }
        
        private IEnumerator FadeIn(Action callback)
        {
            _doneFadingIn = false;
            animator.SetTrigger("FadeIn");
            while (!_doneFadingIn) yield return null;
            
            callback.Invoke();
        }
    }
}