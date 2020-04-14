using UnityEngine;
using UnityEngine.EventSystems; 

public class ButtonPointer : MonoBehaviour, IPointerEnterHandler
{
    public RectTransform panelRectTransform;


    public void OnPointerEnter(PointerEventData eventData)
    {
        panelRectTransform.SetAsFirstSibling();
    }
}
