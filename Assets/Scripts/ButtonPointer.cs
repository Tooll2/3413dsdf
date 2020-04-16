using System;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ButtonPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TowerManagerSolo managerSolo;

    private void Start()
    {
        managerSolo = FindObjectOfType<TowerManagerSolo>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        managerSolo.button = true;
        managerSolo.textTowerInfo.text = "LVL: " + (managerSolo.shootTower.lvl + 1) + " + 1"  + Environment.NewLine + "Damage: " + managerSolo.shootTower.bulletDamage +" " + "("+managerSolo.damage[managerSolo.shootTower.lvl]+")" + Environment.NewLine + "Upgrade cost: " + managerSolo.shootTower.priceUp[managerSolo.shootTower.lvl];

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        managerSolo.button = false;
        managerSolo.textTowerInfo.text = "LVL: " + (managerSolo.shootTower.lvl + 1) + Environment.NewLine + "Damage: " + managerSolo.shootTower.bulletDamage + Environment.NewLine + "Upgrade cost: " + managerSolo.shootTower.priceUp[managerSolo.shootTower.lvl];

    }
}
