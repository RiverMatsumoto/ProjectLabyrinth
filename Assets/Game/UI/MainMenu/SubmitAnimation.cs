using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.MainMenu
{
    public class SubmitAnimation : MonoBehaviour, ISubmitHandler, IPointerClickHandler
    {
        [SerializeField] private float scaleAmount = 1.5f;
        [SerializeField] private float animLength = 0.1f;
        private Vector3 _originalScale;
        private Sequence _sequence;
        
        private void Awake()
        {
            _originalScale = transform.localScale;
            _sequence = DOTween.Sequence().SetAutoKill(false);
            _sequence.Append(transform.DOScale(_originalScale * scaleAmount, animLength).SetEase(Ease.OutQuart)
                .OnComplete(FinishSubmit));
        }

        public void OnSubmit(BaseEventData eventData) => _sequence.PlayForward();
        public void OnPointerClick(PointerEventData eventData) => _sequence.PlayForward();
        
        public void FinishSubmit() => _sequence.PlayBackwards();
    }
}
