using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
    public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Range(-1,1)] [SerializeField] private float _valueToRotateScale;
        [SerializeField] private InputReader _input;

        public void OnPointerDown(PointerEventData eventData)
        {
            _input.TryRotate(_valueToRotateScale);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _input.TryRotate(0f);
        }
    }
}