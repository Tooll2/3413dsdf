using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMobsSingle : MonoBehaviour
{
    public GameObject[] mobs;
    private Transform respownPoint;
    public int wave, maxWave = 20;
	public int money, waveTemp, timer = 10, life = 20;
	public Text timerText, moneyText, waveText, textLife;
    private IEnumerator instMob;

    private void Start()
    {
        respownPoint = transform;
        instMob = Instmobs();

        StartCoroutine(TimerIncome());
        StartCoroutine(instMob);

    }
    private void FixedUpdate()
    {
        moneyText.text = "Gold " + money;
    }






    public IEnumerator Instmobs()
    {
        for (wave = 1; wave <= maxWave; wave++)
        {
            yield return new WaitForSecondsRealtime(1);
            for (int i = 0; i <= 5 + (wave * Random.Range(1, 4)) / 2; i++)
            {
                if (wave >= 10)
                {
                    Instantiate(mobs[Random.Range(wave - 10, 11)], respownPoint.position, respownPoint.rotation);
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
                timer = 10;
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
