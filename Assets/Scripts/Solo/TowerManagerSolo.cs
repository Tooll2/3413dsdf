using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManagerSolo : MonoBehaviour
{

    TowerButton towerButtonPressed;
    public GameObject towersParent;
    Vector2 mousePoint;
    public CreateMobsSingle money;
    public GameObject tower;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

            if (sprite.sprite != null && sprite.sprite.name != null)
            {
                if (sprite.enabled && sprite.sprite.name == "Tower" && hit.collider == null && money.money >= 10)
                {
                    PlacedTower(mousePoint);
                    money.money -= 10;
                }
                if (hit.collider != null)
                    if (hit.collider.CompareTag("Tower") && sprite.enabled && sprite.sprite.name == "UI2_7")
                        DelTower(hit);
            }
            if (hit.collider != null)
                if (hit.collider.CompareTag("Tower") && sprite.enabled && sprite.sprite.name == "UI1_29")
                {
                    ShootTowerSolo shootTower = hit.collider.GetComponent<ShootTowerSolo>();
                  
                    switch (shootTower.lvl)
                    {
                        case 1:
                            if (money.money >= shootTower.priceUp[0])
                            {
                                hit.collider.GetComponent<SpriteRenderer>().color = Color.red;
                                shootTower.bulletDamage = 40;
                                shootTower.lvl += 1;
                                money.money -= shootTower.priceUp[0];
                            }
                                break;
                        case 2:
                            if (money.money >= shootTower.priceUp[1])
                            {
                                hit.collider.GetComponent<SpriteRenderer>().color = Color.black;
                                shootTower.bulletDamage = 100;
                                shootTower.lvl += 1;
                                money.money -= shootTower.priceUp[1];
                            }
                            break;
                        case 3:
                            if (money.money >= shootTower.priceUp[2])
                            {
                                hit.collider.GetComponent<SpriteRenderer>().color = Color.green;
                                shootTower.bulletDamage = 250;
                                shootTower.lvl += 1;
                                money.money -= shootTower.priceUp[2];
                            }
                            break;
                        case 4:
                            if (money.money >= shootTower.priceUp[3])
                            {
                                hit.collider.GetComponent<SpriteRenderer>().color = Color.cyan;
                                shootTower.bulletDamage = 550;
                                shootTower.lvl += 1;
                                money.money -= shootTower.priceUp[3];
                            }
                            break;
                        case 5:
                            if (money.money >= shootTower.priceUp[4])
                            {
                                hit.collider.GetComponent<SpriteRenderer>().color = Color.yellow;
                                shootTower.bulletDamage = 950;
                                shootTower.lvl += 1;
                                money.money -= shootTower.priceUp[4];
                            }
                            break;
                    }

                }
        }

        if (Input.GetMouseButtonDown(1))
            DisableDrug();

        FollowMouse();
    }

    public void PlacedTower(Vector2 hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerButtonPressed != null)
        {
            GameObject newTower = Instantiate(tower, towersParent.transform.position, towersParent.transform.rotation);
            float x = Mathf.Round(hit.x);
            float y = Mathf.Round(hit.y);
            newTower.transform.position = new Vector2(x, y);
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
