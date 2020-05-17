using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManagerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public Image Image;

    public void OnPointerDown(PointerEventData eventData) {
        Image.enabled = false;
    }

    public void OnPointerUp(PointerEventData eventData) {
        Image.enabled = true;
    }
}
