using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerManagerSolo : MonoBehaviour
{

    TowerButton towerButtonPressed;
    public GameObject towersParent;
    Vector2 mousePoint;
    RaycastHit2D hit;
    public ShootTowerSolo shootTower;
    public CreateMobsSingle money;
    public GameObject tower, panelUpTowers, imageFrame;
    public Sprite[] spritesTowers;
    public Text textTowerInfo;
    public bool button;

    public readonly int[] damage = new int[5] { 40, 100, 250, 550, 950 };

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {   
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePoint, Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            if (sprite.sprite != null && sprite.sprite.name != null)
                if (sprite.enabled && sprite.sprite.name == "Tower" && hit.collider == null && money.money >= 10)
                    PlacedTower(mousePoint);
            if (hit.collider != null && !sprite.enabled && button == false)
            {
                if (hit.collider.CompareTag("Tower"))
                {
                    shootTower = hit.collider.GetComponent<ShootTowerSolo>();
                    imageFrame.transform.position = shootTower.transform.position;
                    imageFrame.SetActive(true);
                    panelUpTowers.SetActive(imageFrame.activeSelf);
                    panelUpTowers.transform.position = shootTower.transform.position + new Vector3(0, 2, 0);
                    if (shootTower.lvl <= 4)
                        textTowerInfo.text = "LVL: " + (shootTower.lvl + 1) + Environment.NewLine + "Damage: " + shootTower.bulletDamage + Environment.NewLine + "Upgrade cost: " + shootTower.priceUp[shootTower.lvl];
                    else
                        textTowerInfo.text = "LVL: " + (shootTower.lvl + 1) + Environment.NewLine + "Damage: " + shootTower.bulletDamage + Environment.NewLine + "Upgrade cost: MAX";
                }
            }
        }
        FollowMouse();
        if (Input.GetMouseButtonDown(1))
        {
            DisableDrug();
            imageFrame.SetActive(false);
            panelUpTowers.SetActive(imageFrame.activeSelf);
        }
    }

    public void DelTowerButton()
    {
        Destroy(shootTower.gameObject);
        imageFrame.SetActive(false);
        panelUpTowers.SetActive(imageFrame.activeSelf);
    }

    public void UpTowers()
    {
        int i = shootTower.lvl;
        if (i <= 4)
            if (money.money >= shootTower.priceUp[i])
            {
                shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[i];
                shootTower.bulletDamage = damage[i];
                shootTower.lvl += 1;
                money.money -= shootTower.priceUp[i];
                if (shootTower.lvl <= 4)
                    textTowerInfo.text = "LVL: " + (shootTower.lvl + 1) + Environment.NewLine + "Damage: " + damage[i] + Environment.NewLine + "Upgrade cost: " + shootTower.priceUp[shootTower.lvl];
                else
                    textTowerInfo.text = "LVL: " + (shootTower.lvl + 1) + Environment.NewLine + "Damage: " + damage[i] + Environment.NewLine + "Upgrade cost: MAX";

            }
    }

    public void PlacedTower(Vector2 hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerButtonPressed != null)
        {
            float x = Mathf.Round(hit.x);
            float y = Mathf.Round(hit.y);
            Instantiate(tower, new Vector2(x, y), towersParent.transform.rotation);
            money.money -= 10;
        }
    }

    public void DelTower(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerButtonPressed != null)
        {
            if (hit.collider.CompareTag("Tower"))
                Destroy(hit.transform.gameObject);
        }
    }

    public void SelectedTower(TowerButton towerSelected)
    {
        towerButtonPressed = towerSelected;
        EnableDrug(towerButtonPressed.DragSprite);
    }

    public void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0.7f, 0.7f, 0);
    }

    public void EnableDrug(Sprite sprite1)
    {
        sprite.enabled = true;
        sprite.sprite = sprite1;
    }
    public void DisableDrug()
    {
        sprite.enabled = false;
    }
}
