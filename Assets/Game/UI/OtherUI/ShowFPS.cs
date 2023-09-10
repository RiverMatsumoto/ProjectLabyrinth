using System;
using System.Collections;
using Game.Scripts.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;
using Zenject;
using UniRx;

namespace Game.UI.OtherUI
{
    public class ShowFPS : MonoBehaviour
    {
        [Inject, ShowInInspector] private SettingsData _settingsData;
        private TMP_Text _text;
        private IDisposable _fpsSubscription;
        
        private IEnumerator UpdateFps()
        {
            while (_settingsData.showFps.Value)
            {
                _text.text = $"FPS: {(1f / Time.smoothDeltaTime).ToString("F0")}";
                yield return null;
            }
        }

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            _fpsSubscription = _settingsData.showFps.Subscribe(visibility =>
            {
                _text.enabled = visibility;
                StartCoroutine(UpdateFps());
            });
        }
    }
}
