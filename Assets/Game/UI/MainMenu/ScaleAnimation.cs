using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.MainMenu
{
    public class ScaleAnimation : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public float scaleAmount = 1.2f;
        public float selectAnimLength = 0.1f;
        private Sequence _sequence;

        private void Awake()
        {
            Vector3 originalScale = transform.localScale;
            _sequence = DOTween.Sequence().SetAutoKill(false);
            _sequence.Append(transform.DOScale(originalScale * scaleAmount, selectAnimLength));
            _sequence.Rewind();
        }

        public void OnSelect(BaseEventData eventData) => _sequence.PlayForward();
        public void OnDeselect(BaseEventData eventData) => _sequence.PlayBackwards();
        public void OnPointerEnter(PointerEventData eventData) => _sequence.PlayForward();
        public void OnPointerExit(PointerEventData eventData) => _sequence.PlayBackwards();
    }
}
