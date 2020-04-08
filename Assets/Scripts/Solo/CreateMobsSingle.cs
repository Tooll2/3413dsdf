using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMobsSingle : MonoBehaviour
{
    public GameObject[] mobs;
    private Transform respownPoint;
    public int wave, maxWave = 20;
    public int money, waveTemp, timer = 15, life = 20;
    public Text timerText, moneyText, waveText, textLife;
    private IEnumerator instMob;

    private void Start()
    {
        respownPoint = transform;
        instMob = Instmobs();
        StartCoroutine(instMob);
        StartCoroutine(TimerIncome());

    }
    private void FixedUpdate()
    {
        moneyText.text = "Gold " + money;
    }






    public IEnumerator Instmobs()
    {
        for (wave = 1; wave <= maxWave; wave++)
        { 
            yield return new WaitForSecondsRealtime(15);
            for (int i = 0; i <= 5 + (wave * Random.Range(1, 4)) / 1.5; i++)
            {
                if (wave >= 10 && wave < 20)
                {
                    Instantiate(mobs[Random.Range(wave - 10, 11)], respownPoint.position, respownPoint.rotation);
                    yield return new WaitForSecondsRealtime(0.5f);
                }
                else if (wave >=20)
                {
                    Instantiate(mobs[Random.Range(wave - 20, 11)], respownPoint.position, respownPoint.rotation);
                    yield return new WaitForSecondsRealtime(0.5f);
                }
                else
                {
                    Instantiate(mobs[Random.Range(0, wave)], respownPoint.position, respownPoint.rotation);
                    yield return new WaitForSecondsRealtime(0.5f);
                }
                waveText.text = wave + " / " + maxWave;
            }
        }
    }



    IEnumerator TimerIncome()
    {
        while (true)
        {
            timer -= 1;
            timerText.text = "Begin " + timer;

            if (timer <= 0)
                break;
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
