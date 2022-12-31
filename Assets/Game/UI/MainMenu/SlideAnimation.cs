using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.MainMenu
{
    public class SlideAnimation : MonoBehaviour,
        ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float moveDistance = 50f;
        [SerializeField] private float animLength = 0.08f;
        [SerializeField] private Vector3 originalScale;
        private Sequence _sequence;

        private void Start()
        {
            originalScale = transform.localScale;
            _sequence = DOTween.Sequence().SetAutoKill(false);
            _sequence.Append(transform.DOLocalMoveX(
                    transform.localPosition.x + moveDistance,
                    animLength)
                .SetEase(Ease.OutSine));
            _sequence.Rewind();
        }

        public void OnSelect(BaseEventData eventData) => _sequence.PlayForward();

        public void OnDeselect(BaseEventData eventData) => _sequence.PlayBackwards();

        public void OnPointerEnter(PointerEventData eventData) => _sequence.PlayForward();

        public void OnPointerExit(PointerEventData eventData) => _sequence.PlayBackwards();
    }
}