using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMobs : MonoBehaviour
{
    public GameObject[] mobs;
    public GameObject panel, buttonPanel;
    private Transform respownPoint;
    public int[] prices, incomes, counts;
    Money money;
    public Text[] countsText;
    public Image[] imagesButtons;
    public float[] counts2, timeRefresh, timeVel;
    public bool single;


    private int lvlCreeps;
    private IEnumerator fillImageCorutine;
    private readonly bool[] active = new bool[11] { false, false, false, false, false, false, false, false, false, false, false };

    private void Start()
    {
        fillImageCorutine = FillImage();
        lvlCreeps = 0;
        StartCoroutine(fillImageCorutine);
        respownPoint = transform;
        money = GetComponent<Money>();
    }


    public void Create(int index)
    {
        if (money.money >= prices[index] && counts[index] != 0)
        {
            Instantiate(mobs[index], respownPoint.position, respownPoint.rotation);
            counts[index] -= 1;
            counts2[index] -= 1;
            countsText[index].text = "" + counts[index];
            money.money -= prices[index];
            GetIncome(index);
        }
        if (counts[index] == 0)
        {
            imagesButtons[index].GetComponent<Button>().interactable = false;
        }
    }
    public void GetIncome(int index)
    {
        money.income += incomes[index];
        money.incomeText.text = "" + money.income;
    }

    public void lvlCreepsUp()
    {
        StopCoroutine(fillImageCorutine);
        lvlCreeps++;
        StartCoroutine(fillImageCorutine);
    }



    IEnumerator FillImage()
    {
        float speed = 15f;
        while (true)
        {
            for (int i = 0 + lvlCreeps * 11; i <= 10 + lvlCreeps * 11; i++)
            {
                if (counts2[i] <= 8)
                {
                    if (!active[i])
                        counts2[i] += 1 / (timeVel[i] * speed);
                    else
                        counts2[i] += 1 / (timeRefresh[i] * speed);

                    imagesButtons[i].fillAmount = counts2[i];

                    if ((int)counts2[i] > counts[i])
                    {
                        counts[i] += 1;
                        countsText[i].text = "" + counts[i];
                        active[i] = true;
                    }
                    if (counts[i] > 0)
                        imagesButtons[i].GetComponent<Button>().interactable = true;
                    else
                        imagesButtons[i].GetComponent<Button>().interactable = false;
                }
            }

            yield return new WaitForSecondsRealtime(1 / speed);
        }
    }


    public void ClosePanel()
    {
        panel.SetActive(!panel.activeSelf);
        buttonPanel.SetActive(!buttonPanel.activeSelf);
    }
}




