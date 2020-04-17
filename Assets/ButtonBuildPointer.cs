using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBuildPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TowerManagerSolo managerSolo;

    private void Start()
    {
        managerSolo = FindObjectOfType<TowerManagerSolo>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        managerSolo.button = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        managerSolo.button = false;
    }
}
