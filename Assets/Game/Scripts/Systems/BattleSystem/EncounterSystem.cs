using System;
using System.Collections;
using Game.Scripts.Movement;
using Game.Scripts.Signals;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Scripts.Systems.BattleSystem
{
    public class EncounterSystem : MonoBehaviour
    {
        [Inject, ShowInInspector] private PlayerMovement _playerMovement;
        public ReactiveCommand stepTaken;
        private Tilemap dangerTilemap; // TODO Inject later. A tilemap with a multiplier that 
        public float dangerMultiplier = 1f;


        private float _gauge;
        public float gauge
        {
            get => _gauge;
            private set
            {
                // stepTaken.Execute();
                stepTaken.Execute();
                _gauge = value;
            }
        }

        private void Awake()
        {
            // stepTaken = new ReactiveCommand();
            stepTaken = new ReactiveCommand();
        }

        private void Start()
        {
            _playerMovement.moveEnded.Subscribe(_ => Stepped());
        }


        public void Stepped()
        {
            float increase = dangerMultiplier * Random.Range(0f, 0.11f);
            gauge += increase;
            if (gauge >= 1f)
            {
                Encounter();
                StartCoroutine(DelayResetGauge());
            }
        }

        private IEnumerator DelayResetGauge()
        {
            yield return new WaitForSeconds(0.15f);
            gauge = 0f;
        }

        // LOTS of dynamic factories and such needed for encountering enemies
        public void Encounter()
        {
            UnityEngine.Debug.Log("Encountered enemies");
        }
    }
}
