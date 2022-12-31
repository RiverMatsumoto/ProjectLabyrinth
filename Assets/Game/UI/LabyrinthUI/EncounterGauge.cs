using System;
using DG.Tweening;
using Game.Scripts.Systems.BattleSystem;
using RengeGames.HealthBars;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.UI.LabyrinthUI
{
    public class EncounterGauge : MonoBehaviour
    {
        [Inject] private EncounterSystem _encounterSystem;
        private RadialSegmentedHealthBar _encounterGauge;

        private void Start()
        {
            _encounterGauge = GetComponent<RadialSegmentedHealthBar>();
            _encounterSystem.stepTaken.Subscribe(_ => UpdateGaugeUI());
        }

        public void UpdateGaugeUI()
        {
            float start = _encounterSystem.gauge;
            float end = _encounterSystem.gauge;
            float tweenInterval = 0f;
            DOTween.To(
                () => tweenInterval,
                x => tweenInterval = x,
                Mathf.PI/2f,
                0.1f
            ).OnUpdate(() =>
            {
                _encounterGauge.SetPercent(EaseInSineFormula(tweenInterval, start, end));
            });
        }

        private float EaseInSineFormula(float interpolation, float start, float end)
        {
            const float piOverTwo = Mathf.PI / 2f;
            float change = end - start;
            return start + (change * (Mathf.Sin(interpolation - piOverTwo) + 1));
        }
    }
}
