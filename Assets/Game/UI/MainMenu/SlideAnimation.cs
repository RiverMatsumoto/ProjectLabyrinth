using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.MainMenu
{
    public class SlideAnimation : MonoBehaviour,
        ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float moveDistance = 50f;
        [SerializeField] private float scaleAmount = 1.1f;
        [SerializeField] private float tweenTime = 0.08f;
        [SerializeField] private Vector3 originalScale;
        private Sequence _sequence;

        private void Start()
        {
            originalScale = transform.localScale;
            _sequence = DOTween.Sequence().SetAutoKill(false);
            _sequence.Append(transform.DOLocalMoveX(
                    transform.localPosition.x + moveDistance,
                    tweenTime)
                .SetEase(Ease.OutSine));
            // _sequence.Append(transform.DOScale(
            //         originalScale * scaleAmount,
            //         tweenTime / 2)
            //     .SetEase(Ease.OutQuart));
            _sequence.Rewind();
        }

        public void OnSelect(BaseEventData eventData) => _sequence.PlayForward();

        public void OnDeselect(BaseEventData eventData) => _sequence.PlayBackwards();

        public void OnPointerEnter(PointerEventData eventData) => _sequence.PlayForward();

        public void OnPointerExit(PointerEventData eventData) => _sequence.PlayBackwards();
    }
}