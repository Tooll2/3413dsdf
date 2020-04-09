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
                    panelUpTowers.SetActive(true);
                }
            }
        }
        FollowMouse();
        if (Input.GetMouseButtonDown(1))
        {
            DisableDrug();
            panelUpTowers.SetActive(false);
            imageFrame.SetActive(false);
        }
    }

    public void DelTowerButton()
    {
        Destroy(shootTower.gameObject);
        imageFrame.SetActive(false);
    }

    public void UpTowersButton()
    {
        UpTowers(shootTower);
    }

    public void UpTowers(ShootTowerSolo shootTower)
    {
        switch (shootTower.lvl)
        {
            case 1:
                if (money.money >= shootTower.priceUp[0])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[0];
                    shootTower.bulletDamage = 40;
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[0];
                }
                break;
            case 2:
                if (money.money >= shootTower.priceUp[1])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[1];
                    shootTower.bulletDamage = 100;
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[1];
                }
                break;
            case 3:
                if (money.money >= shootTower.priceUp[2])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[2];
                    shootTower.bulletDamage = 250;
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[2];
                }
                break;
            case 4:
                if (money.money >= shootTower.priceUp[3])
                {
                    shootTower.GetComponent<SpriteRenderer>().sprite = spritesTowers[3];
                    shootTower.bulletDamage = 550;
                    shootTower.lvl += 1;
                    money.money -= shootTower.priceUp[3];
                }
                break;
            case 5:
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
