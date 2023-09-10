using System;
using Game.Scripts.Systems.BattleSystem;
using UniRx;
using Zenject;

namespace Game.Scripts.Systems.Commands
{
    public class EncounterMultiplier : ICommand
    {
        private EncounterSystem _es;
        private float _multiplier;
        private readonly int _maxSteps;
        private int _currentSteps;
        private IDisposable _subscription;

        public EncounterMultiplier(EncounterSystem encounterSystem,
            float multiplier, int maxSteps)
        {
            _es = encounterSystem;
            _multiplier = multiplier;
            _maxSteps = maxSteps;
            _currentSteps = 0;
        }
    
        public void Execute()
        {
            UnityEngine.Debug.Log(_es);
            _es.encounterData.encounterMultiplier *= _multiplier;
            _subscription = _es.stepTaken.Subscribe(_ => IncrementStepCounter());
        }

        private void IncrementStepCounter()
        {
            UnityEngine.Debug.Log("Incremented steps");
            if (++_currentSteps >= _maxSteps) Dispose();
        }

        private void Dispose()
        {
            _es.encounterData.encounterMultiplier /= _multiplier;
            _subscription.Dispose();
        }

        public class Factory : PlaceholderFactory<float, int, EncounterMultiplier> { }
    }
}
