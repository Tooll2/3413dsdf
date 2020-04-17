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
        if (managerSolo.shootTower.lvl <= 4)
            managerSolo.textTowerInfo.text = "LVL: " + (managerSolo.shootTower.lvl + 1) + " + 1"  + Environment.NewLine + "Damage: " + managerSolo.shootTower.bulletDamage +" " + "("+managerSolo.damage[managerSolo.shootTower.lvl]+")" + Environment.NewLine + "Upgrade cost: " + managerSolo.shootTower.priceUp[managerSolo.shootTower.lvl];
        else
            managerSolo.textTowerInfo.text = "LVL: " + (managerSolo.shootTower.lvl + 1) + Environment.NewLine + "Damage: " + managerSolo.shootTower.bulletDamage + Environment.NewLine + "Upgrade cost: MAX";

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        managerSolo.button = false;
        if (managerSolo.shootTower.lvl <= 4)
            managerSolo.textTowerInfo.text = "LVL: " + (managerSolo.shootTower.lvl + 1) + Environment.NewLine + "Damage: " + managerSolo.shootTower.bulletDamage + Environment.NewLine + "Upgrade cost: " + managerSolo.shootTower.priceUp[managerSolo.shootTower.lvl];
        else
            managerSolo.textTowerInfo.text = "LVL: " + (managerSolo.shootTower.lvl + 1) + Environment.NewLine + "Damage: " + managerSolo.shootTower.bulletDamage + Environment.NewLine + "Upgrade cost: MAX";
    }
}
