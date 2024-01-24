using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.UI
{
    public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public RectTransform background;
        public RectTransform handle;

        private Vector2 inputVector;
        private bool _isActive = true;


        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            inputVector = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isActive) return;

            Vector2 direction = eventData.position - (Vector2)background.position;
            inputVector = (direction.magnitude > background.sizeDelta.x / 2f)
                ? direction.normalized
                : direction / (background.sizeDelta.x / 2f);

            handle.anchoredPosition = inputVector * background.sizeDelta.x / 2f;
        }

        public void SetActive(bool status)
        {
            gameObject.SetActive(status);
            _isActive = status;

        }

        public float Horizontal() => inputVector.x;
        public float Vertical() => inputVector.y;
    }
}
