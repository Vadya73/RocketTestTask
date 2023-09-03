using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI
{
    public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private InputReader _input;

        public void OnPointerDown(PointerEventData eventData)
        {
            _input.TryMove(true);
            Debug.Log("true");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _input.TryMove(false);
            Debug.Log("false");
        }
    }
}