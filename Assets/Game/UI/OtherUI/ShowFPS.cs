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
        private TMP_Text text;
        private CompositeDisposable _disposables;

        
        private void OnEnable()
        {
            _disposables = new CompositeDisposable();
            text = GetComponent<TMP_Text>();
            _settingsData.showFps.Subscribe(toggle =>
            {
                text.enabled = toggle;
                StartCoroutine(UpdateFps());
            }).AddTo(_disposables);
            if (_settingsData.showFps.Value) StartCoroutine(UpdateFps());
        }

        private void OnDisable() => _disposables.Clear();

        private IEnumerator UpdateFps()
        {
            while (_settingsData.showFps.Value)
            {
                text.text = $"FPS: {1f / Time.unscaledDeltaTime}";
                yield return new WaitForSeconds(0.05f);
            }
        }
        
    }
}
