using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManagerSolo : MonoBehaviour
{

    TowerButton towerButtonPressed;
    public GameObject towersParent;
    Vector2 mousePoint;
    RaycastHit2D hit;
    ShootTowerSolo shootTower;
    public CreateMobsSingle money;
    public GameObject tower, panelUpTowers, imageFrame;
    public Sprite[] spritesTowers;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        hit = Physics2D.Raycast(mousePoint, Vector2.zero);
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (sprite.sprite != null && sprite.sprite.name != null)
                if (sprite.enabled && sprite.sprite.name == "Tower" && hit.collider == null && money.money >= 10)
                    PlacedTower(mousePoint);
            if (hit.collider != null && !sprite.enabled)
            {
                if (hit.collider.CompareTag("Tower"))
                {
                    shootTower = hit.collider.GetComponent<ShootTowerSolo>();
                    imageFrame.transform.position = shootTower.transform.position;
                    imageFrame.SetActive(true);
                    panelUpTowers.SetActive(imageFrame.activeSelf);
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
        int[] damage = new int[5] { 40, 100, 250, 550, 950 };

        switch (shootTower.lvl)
        {  
            case 0:
                if (money.money >= shootTower.priceUp[shootTower.lvl])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[shootTower.lvl];
                    shootTower.bulletDamage = damage[shootTower.lvl];
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[shootTower.lvl];
                }
                break;
            case 1:
                if (money.money >= shootTower.priceUp[shootTower.lvl])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[shootTower.lvl];
                    shootTower.bulletDamage = 100;
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[shootTower.lvl];
                }
                break;
            case 2:
                if (money.money >= shootTower.priceUp[shootTower.lvl])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[shootTower.lvl];
                    shootTower.bulletDamage = 250;
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[shootTower.lvl];
                }
                break;
            case 3:
                if (money.money >= shootTower.priceUp[3])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[3];
                    shootTower.bulletDamage = 550;
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[3];
                }
                break;
            case 4:
                if (money.money >= shootTower.priceUp[4])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[4];
                    shootTower.bulletDamage = 950;
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[4];
                }
                break;
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
