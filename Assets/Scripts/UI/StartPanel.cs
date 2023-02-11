using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class StartPanel : MonoBehaviour, IDragHandler,IBeginDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            gameObject.SetActive(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
}