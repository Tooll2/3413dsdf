using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMobsSingle : MonoBehaviour
{
    public GameObject[] mobs;
    private Transform respownPoint;
    public int wave, maxWave = 20;
    public int money, life = 20;
    public Text moneyText, waveText, textLife;
    private IEnumerator instMob;
    public float countSpawn;
    public int timerWave, maxCount;


    private void Start()
    {
        respownPoint = GetComponent<Transform>();
        instMob = Instmobs();
        StartCoroutine(instMob);
        waveText.text = wave + " / " + maxWave;
    }
    private void FixedUpdate()
    {
        moneyText.text = "Gold " + money;
    }






    public IEnumerator Instmobs()
    {
        int rnd;
        for (wave = 1; wave <= maxWave; wave++)
        { 
            yield return new WaitForSecondsRealtime(timerWave);
            for (int i = 0; i <= 5 + (wave * (Random.Range(1, 5) * countSpawn)); i++)
            {
                if (wave >= 10 && wave < 20)
                    rnd = Random.Range(wave - 10, 11);
                else if (wave >=20)
                    rnd = Random.Range(11, (int)(0.7f * (wave - maxCount)) + 13);
                else
                    rnd = Random.Range(0, wave);

                Instantiate(mobs[rnd], respownPoint.position, respownPoint.rotation);
                yield return new WaitForSecondsRealtime(Random.Range(0.2f, 1));
                waveText.text = wave + " / " + maxWave;
            }
        }
    }

}
