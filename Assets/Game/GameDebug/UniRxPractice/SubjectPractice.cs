using System;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.GameDebug.UniRxPractice
{
    public class SubjectPractice : MonoBehaviour
    {
        public Subject<int> _subject = new Subject<int>();
        public TMP_Text text;
        public Button button;
        private ReactiveProperty<Vector2Int> position = new ReactiveProperty<Vector2Int>();
        public ReactiveCommand MyEvent;
        public IDisposable firstSubscription;
        public IDisposable secondSubscription;

        private void Start()
        {
            _subject.Subscribe(next => text.text = next.ToString());
            // var textObs = Observable
            //     .IntervalFrame(1, FrameCountType.FixedUpdate)
            //     .TakeUntil(Observable.Timer(TimeSpan.FromSeconds(10)))
            //     .Subscribe(
            //         x => _subject.OnNext((int)x),
            //         () => UnityEngine.Debug.Log("Completed")
            //     );

            MyEvent = new ReactiveCommand();
            firstSubscription = MyEvent.Subscribe(_ => ReactToEvent());
            secondSubscription = MyEvent.Subscribe(_ => ReactToEvent());
        }

        [Button]
        public void BroadcastEvent() => MyEvent.Execute();

        [Button]
        public void UnsubscribeFirst() => firstSubscription.Dispose();
        
        [Button]
        public void UnsubscribeSecond() => secondSubscription.Dispose();

        [Button]
        public void AddFirstSubscriber() => firstSubscription = MyEvent.Subscribe(_ => ReactToEvent());
        [Button]
        public void AddSecondSubscriber() => secondSubscription = MyEvent.Subscribe(_ => ReactToEvent());

        [Button]
        public void ReactToEvent()
        {
            UnityEngine.Debug.Log($"First Subscription: {firstSubscription.ToString()}");
            UnityEngine.Debug.Log($"Second Subscription: {secondSubscription.ToString()}");
        }
    }
}
